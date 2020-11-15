using System;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.RgbArgs;
using ImageProcessing.App.PresentationLayer.Presenters.Base;
using ImageProcessing.App.PresentationLayer.Presenters.ColorMatrix;
using ImageProcessing.App.PresentationLayer.Properties;
using ImageProcessing.App.PresentationLayer.ViewModel.ColorMatrix;
using ImageProcessing.App.PresentationLayer.ViewModel.Rgb;
using ImageProcessing.App.PresentationLayer.Views.Rgb;
using ImageProcessing.App.ServiceLayer.Providers.Rgb.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Block.Implementation;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

namespace ImageProcessing.App.PresentationLayer.Presenters.Rgb
{
    internal sealed class RgbPresenter : BasePresenter<IRgbView, RgbViewModel>,
          ISubscriber<ApplyRgbFilterEventArgs>,
          ISubscriber<ApplyRgbColorFilterEventArgs>,
          ISubscriber<ContainerUpdatedEventArgs>,
          ISubscriber<ShowColorMatrixMenuEventArgs>
    {
        private readonly IRgbServiceProvider _provider;
        private readonly IAsyncOperationLocker _locker;

        public RgbPresenter(
            IAppController controller,
            IRgbServiceProvider provider,
            IAsyncOperationLocker locker) : base(controller)
        {
            _provider = provider;
            _locker = locker;
        }

        public async Task OnEventHandler(object publisher, ApplyRgbFilterEventArgs e)
        {
            try
            {
                var filter = View.Dropdown;

                if (filter != RgbFltr.Unknown)
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
                View.Tooltip(Errors.ApplyRgbFilter);
            }
        }

        public async Task OnEventHandler(object publisher, ApplyRgbColorFilterEventArgs e)
        {
            try
            {
                var color = View.GetSelectedColors(e.Color);

                var copy = await _locker.LockOperationAsync(
                    () => new Bitmap(ViewModel.Source)
                ).ConfigureAwait(true);

                Controller.Aggregator.PublishFromAll(
                    e.Publisher,
                    new AttachBlockToRendererEventArgs(
                        block: new PipelineBlock(copy)
                            .Add<Bitmap, Bitmap>(
                                (bmp) => _provider.Apply(bmp, color))
                    )
                 );
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.ApplyColorFilter);
            }
        }

        public async Task OnEventHandler(object publisher, ShowTooltipOnErrorEventArgs e)
        {
            View.Tooltip(e.Error);
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

        public async Task OnEventHandler(object publisher, ShowColorMatrixMenuEventArgs e)
        {
            try
            {
                var copy = await _locker.LockOperationAsync(
                    () => new Bitmap(ViewModel.Source)
                ).ConfigureAwait(true);

                Controller.Run<ColorMatrixPresenter, ColorMatrixViewModel>(
                    new ColorMatrixViewModel(copy));
            }
            catch(Exception ex)
            {

            }
        }
    }
}
