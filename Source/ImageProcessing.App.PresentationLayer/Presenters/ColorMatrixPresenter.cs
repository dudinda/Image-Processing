using System;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.ColorMatrix.Interface;
using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.DomainEvents.ColorMatrixArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.Properties;
using ImageProcessing.App.PresentationLayer.ViewModels;
using ImageProcessing.App.PresentationLayer.Views.ColorMatrix;
using ImageProcessing.App.ServiceLayer.Providers.Rgb.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Block.Implementation;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.PresentationLayer.Presenters
{
    internal sealed class ColorMatrixPresenter : BasePresenter<IColorMatrixView, ColorMatrixViewModel>,
        ISubscriber<ApplyColorMatrixEventArgs>,
        ISubscriber<ContainerUpdatedEventArgs>,
        ISubscriber<CustomColorMatrixEventArgs>,
        ISubscriber<ChangeColorMatrixEventArgs>,
        ISubscriber<ApplyCustomColorMatrixEventArgs>,
        ISubscriber<RestoreFocusEventArgs>
    {
        private readonly IRgbServiceProvider _provider;
        private readonly IAsyncOperationLocker _locker;
        private readonly IColorMatrixFactory _factory;

        public ColorMatrixPresenter(
            IRgbServiceProvider provider,
            IAsyncOperationLocker locker,
            IColorMatrixFactory factory)
        {
            _provider = provider;
            _factory = factory;
            _locker = locker;         
        }

        /// <inheritdoc cref="ApplyColorMatrixEventArgs"/>
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
                        publisher,
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

        /// <inheritdoc cref="ApplyCustomColorMatrixEventArgs"/>
        public async Task OnEventHandler(object publisher, ApplyCustomColorMatrixEventArgs e)
        {
            try
            {
                var copy = await _locker.LockOperationAsync(
                    () => new Bitmap(ViewModel.Source)
                ).ConfigureAwait(true);

                var matrix = View.GetGrid();

                Controller.Aggregator.PublishFromAll(
                    publisher,
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

        /// <inheritdoc cref="CustomColorMatrixEventArgs"/>
        public async Task OnEventHandler(object publisher, CustomColorMatrixEventArgs e)
        {
            try
            {
                View.SetEnabledCells(!e.UseCustom);
                View.SetEnabledDropDown(!e.UseCustom);
                View.SetVisibleApply(!e.UseCustom);
                View.SetVisibleApplyCustom(e.UseCustom);
                View.SetGrid(_factory.Get(View.Dropdown).Matrix);
            }
            catch(Exception ex)
            {
                View.Tooltip(Errors.CustomColorMatrix);
            }
        }

        /// <inheritdoc cref="ChangeColorMatrixEventArgs"/>
        public async Task OnEventHandler(object publisher, ChangeColorMatrixEventArgs e)
        {
            try
            {
                View.SetGrid(_factory.Get(View.Dropdown).Matrix);
            }
            catch(Exception ex)
            {
                View.Tooltip(Errors.UpdateColorMatrix);
            }
        }

        /// <inheritdoc cref="ContainerUpdatedEventArgs"/>
        public async Task OnEventHandler(object publisher, ContainerUpdatedEventArgs e)
        {
            try
            {
                if (e.Container == ImageContainer.Source)
                {
                    await _locker.LockOperationAsync(() =>
                    {
                        lock (e.Bmp)
                        {
                            ViewModel.Source = new Bitmap(e.Bmp);
                        }
                    }).ConfigureAwait(true);
                }
            }
            catch(Exception ex)
            {
                View.Tooltip(Errors.UpdatingViewModel);
            }
        }

        /// <inheritdoc cref="RestoreFocusEventArgs"/>
        public async Task OnEventHandler(object publisher, RestoreFocusEventArgs e)
        {
            View.Focus();
        }
    }
}
