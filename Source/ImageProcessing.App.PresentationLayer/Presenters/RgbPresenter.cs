using System;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.RgbArgs;
using ImageProcessing.App.PresentationLayer.Presenters.ColorMatrix;
using ImageProcessing.App.PresentationLayer.Properties;
using ImageProcessing.App.PresentationLayer.ViewModels.ColorMatrix;
using ImageProcessing.App.PresentationLayer.ViewModels.Rgb;
using ImageProcessing.App.PresentationLayer.Views.Rgb;
using ImageProcessing.App.ServiceLayer.Providers.Rgb.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Block.Implementation;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.PresentationLayer.Presenters.Rgb
{
    internal sealed class RgbPresenter : BasePresenter<IRgbView, RgbViewModel>,
          ISubscriber<ApplyRgbFilterEventArgs>,
          ISubscriber<ApplyRgbChannelFilterEventArgs>,
          ISubscriber<ContainerUpdatedEventArgs>,
          ISubscriber<ShowColorMatrixMenuEventArgs>,
          ISubscriber<ShowTooltipOnErrorEventArgs>,
          ISubscriber<RestoreFocusEventArgs>
    {
        private readonly IRgbServiceProvider _provider;
        private readonly IAsyncOperationLocker _locker;

        public RgbPresenter(
            IRgbServiceProvider provider,
            IAsyncOperationLocker locker) 
        {
            _provider = provider;
            _locker = locker;
        }

        /// <inheritdoc cref="ApplyRgbFilterEventArgs"/>
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
                View.Tooltip(Errors.ApplyRgbFilter);
            }
        }

        /// <inheritdoc cref="ApplyRgbChannelFilterEventArgs"/>
        public async Task OnEventHandler(object publisher, ApplyRgbChannelFilterEventArgs e)
        {
            try
            {
                var color = View.GetSelectedChannels(e.Channel);

                var copy = await _locker.LockOperationAsync(
                    () => new Bitmap(ViewModel.Source)
                ).ConfigureAwait(true);

                Controller.Aggregator.PublishFromAll(
                    publisher,
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

        /// <inheritdoc cref="ShowColorMatrixMenuEventArgs"/>
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
                View.Tooltip(Errors.ShowColorMatrixMenu);
            }
        }

        /// <inheritdoc cref="ShowTooltipOnErrorEventArgs"/>
        public async Task OnEventHandler(object publisher, ShowTooltipOnErrorEventArgs e)
        {
            View.Tooltip(e.Message);
        }

        /// <inheritdoc cref="RestoreFocusEventArgs"/>
        public async Task OnEventHandler(object publisher, RestoreFocusEventArgs e)
        {
            View.Focus();
        }
    }
}
