using System;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.RgbFilter.Interface;
using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.RgbArgs;
using ImageProcessing.App.PresentationLayer.Properties;
using ImageProcessing.App.PresentationLayer.ViewModels;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Providers.Rgb.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Block.Implementation;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.PresentationLayer.Presenters
{
    internal sealed class RgbPresenter : BasePresenter<IRgbView, RgbViewModel>,
          ISubscriber<ApplyRgbFilterEventArgs>,
          ISubscriber<ApplyRgbChannelFilterEventArgs>,
          ISubscriber<ContainerUpdatedEventArgs>,
          ISubscriber<ShowColorMatrixMenuEventArgs>,
          ISubscriber<ShowTooltipOnErrorEventArgs>,
          ISubscriber<RestoreFocusEventArgs>
    {
        private readonly IRgbProvider _provider;
        private readonly IRgbFilterFactory _factory;
        private readonly IAsyncOperationLocker _locker;

        public RgbPresenter(
            IRgbProvider provider,
            IRgbFilterFactory factory,
            IAsyncOperationLocker locker) 
        {
            _provider = provider;
            _factory = factory;
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
                    var color = View.GetSelectedChannels();

                    var copy = await _locker.LockOperationAsync(
                        () => new Bitmap(ViewModel.Source)
                    ).ConfigureAwait(true);

                    Controller.Aggregator.PublishFromAll(
                        publisher,
                        new AttachBlockToRendererEventArgs(
                            block: new PipelineBlock(copy)
                                .Add<Bitmap, Bitmap>(
                                    (bmp) => _factory.Get(color).Filter(bmp))
                                .Add<Bitmap, Bitmap>(
                                    (bmp) => _factory.Get(filter).Filter(bmp))
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
                var color = View.GetSelectedChannels();

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
