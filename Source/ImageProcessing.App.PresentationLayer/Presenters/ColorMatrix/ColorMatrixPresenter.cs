using System;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.ColorMatrix;
using ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs;
using ImageProcessing.App.DomainLayer.DomainFactory.ColorMatrix.Interface;
using ImageProcessing.App.PresentationLayer.Presenters.Base;
using ImageProcessing.App.PresentationLayer.Properties;
using ImageProcessing.App.PresentationLayer.ViewModel.ColorMatrix;
using ImageProcessing.App.PresentationLayer.Views.ColorMatrix;
using ImageProcessing.App.ServiceLayer.Providers.Rgb.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Block.Implementation;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

namespace ImageProcessing.App.PresentationLayer.Presenters.ColorMatrix
{
    internal sealed class ColorMatrixPresenter : BasePresenter<IColorMatrixView, ColorMatrixViewModel>,
        ISubscriber<ApplyColorMatrixEventArgs>,
        ISubscriber<ContainerUpdatedEventArgs>,
        ISubscriber<CustomColorMatrixEventArgs>,
        ISubscriber<ChangeColorMatrixEventArgs>,
        ISubscriber<ApplyCustomColorMatrixEventArgs>
    {
        private readonly IRgbServiceProvider _provider;
        private readonly IAsyncOperationLocker _locker;
        private readonly IColorMatrixFactory _factory;

        public ColorMatrixPresenter(
            IAppController controller,
            IRgbServiceProvider provider,
            IAsyncOperationLocker locker,
            IColorMatrixFactory factory) : base(controller)
        {
            _provider = provider;
            _factory = factory;
            _locker = locker;         
        }

        public async Task OnEventHandler(object publisher, ApplyColorMatrixEventArgs e)
        {
            try
            {
                var filter = View.Dropdown;

                if (filter != ClrMatrix.Unknown)
                {
                    var copy = await _locker.LockOperationAsync(
                        () => new Bitmap(ViewModel.Source)
                    ).ConfigureAwait(true);

                    Controller.Aggregator.PublishFromAll(
                        e.Publisher,
                        new AttachBlockToRendererEventArgs(
                            block: new PipelineBlock(copy)
                                .Add<Bitmap, Bitmap>(
                                    (bmp) => _provider.Apply(bmp, filter))
                        )
                     );
                }
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.ApplyColorMatrix);
            }
        }

        public async Task OnEventHandler(object publisher, ApplyCustomColorMatrixEventArgs e)
        {
            try
            {
                var copy = await _locker.LockOperationAsync(
                    () => new Bitmap(ViewModel.Source)
                ).ConfigureAwait(true);

                var matrix = View.GetGrid();

                Controller.Aggregator.PublishFromAll(
                    e.Publisher,
                    new AttachBlockToRendererEventArgs(
                        block: new PipelineBlock(copy)
                            .Add<Bitmap, Bitmap>(
                                (bmp) => _provider.Apply(bmp, matrix))
                    )
                 );
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.ApplyCustomColorMatrix);
            }
        }

        public async Task OnEventHandler(object publisher, CustomColorMatrixEventArgs e)
        {
            try
            {
                View.SetEnabledCells(!e.UseCustom);
                View.SetEnabledDropDown(!e.UseCustom);
                View.SetVisibleApply(!e.UseCustom);
                View.SetVisibleApplyCustom(e.UseCustom);

                if(!e.UseCustom)
                {
                    View.SetGrid(_factory.Get(View.Dropdown).Matrix);
                }
            }
            catch(Exception ex)
            {
                View.Tooltip(Errors.CustomColorMatrix);
            }
        }

        public async Task OnEventHandler(object publisher, ChangeColorMatrixEventArgs e)
        {
            try
            {
                var matrix = View.Dropdown;

                if (matrix == ClrMatrix.Unknown)
                {
                    View.ResetGrid();
                }

                if (matrix != ClrMatrix.Unknown)
                {
                    View.SetGrid(_factory.Get(matrix).Matrix);
                }
            }
            catch(Exception ex)
            {
                View.Tooltip(Errors.UpdateColorMatrix);
            }
        }

        public async Task OnEventHandler(object publisher, ContainerUpdatedEventArgs e)
        {
            if (e.Container == ImageContainer.Source)
            {
                await _locker.LockOperationAsync(() =>
                    ViewModel.Source = new Bitmap(e.Bmp)
                ).ConfigureAwait(true);
            }
        }
    }
}