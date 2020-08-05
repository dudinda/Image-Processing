using System;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.RgbArgs;
using ImageProcessing.App.PresentationLayer.Presenters.Base;
using ImageProcessing.App.PresentationLayer.Properties;
using ImageProcessing.App.PresentationLayer.ViewModel.Rgb;
using ImageProcessing.App.PresentationLayer.Views.Rgb;
using ImageProcessing.App.ServiceLayer.Providers.Interface.RgbFilters;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Block.Implementation;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

namespace ImageProcessing.App.PresentationLayer.Presenters.Rgb
{
    internal sealed partial class RgbPresenter : BasePresenter<IRgbView, RgbViewModel>,
          ISubscriber<ApplyRgbFilterEventArgs>,
          ISubscriber<ApplyRgbColorFilterEventArgs>
    {
        private readonly IRgbFilterServiceProvider _provider;
        private readonly IAsyncOperationLocker _locker;

        public RgbPresenter(
            IAppController controller,
            IRgbFilterServiceProvider provider,
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

                if (filter != RgbFilter.Unknown)
                {
                    var copy = await _locker
                        .LockOperationAsync(
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
            
                if (color != RgbColors.Unknown)
                {
                    var copy = await _locker
                        .LockOperationAsync(
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
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.ApplyColorFilter);
            }
        }

        public Task OnEventHandler(object publisher, ShowTooltipOnErrorEventArgs e)
        {
            View.Tooltip(e.Error);

            return Task.CompletedTask;
        }
    }
}
