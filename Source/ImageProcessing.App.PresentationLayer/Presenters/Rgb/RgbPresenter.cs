using System;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.MainArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.RgbArgs;
using ImageProcessing.App.PresentationLayer.Presenters.Base;
using ImageProcessing.App.PresentationLayer.ViewModel.Rgb;
using ImageProcessing.App.PresentationLayer.Views.Rgb;
using ImageProcessing.App.ServiceLayer.Providers.Interface.RgbFilters;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Block.Implementation;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

namespace ImageProcessing.App.PresentationLayer.Presenters.Rgb
{
    internal sealed partial class RgbPresenter
        : BasePresenter<IRgbView, RgbViewModel>
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

        private async Task ApplyRgbFilter(RgbFilterEventArgs e)
        {
            try
            {
                var filter = View.SelectedFilter;

                if (filter != RgbFilter.Unknown)
                {
                    var copy = await _locker
                        .LockOperationAsync(
                            () => new Bitmap(ViewModel.Source)
                         ).ConfigureAwait(true);

                    var block = new PipelineBlock(copy)
                        .Add<Bitmap, Bitmap>(
                           (bmp) => _provider.Apply(bmp, filter)
                        );

                    Controller.Aggregator.PublishFromAll(
                        new RenderEventArgs(block, e.Publisher)
                     );
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private async Task ApplyColorFilter(RgbColorFilterEventArgs e)
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

                    var block = new PipelineBlock(copy)
                        .Add<Bitmap, Bitmap>(
                           (bmp) => _provider.Apply(bmp, color)
                        );

                    Controller.Aggregator.PublishFromAll(
                        new RenderEventArgs(block, e.Publisher)
                     );
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
