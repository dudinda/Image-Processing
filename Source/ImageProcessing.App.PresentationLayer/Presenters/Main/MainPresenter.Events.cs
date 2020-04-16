using System;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.ConvolutionArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.DistributionArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.RgbArgs;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;

namespace ImageProcessing.App.PresentationLayer.Presenters.Main
{
    public sealed partial class MainPresenter
        : ISubscriber<ApplyConvolutionFilterEventArgs>,
          ISubscriber<ShowConvolutionFilterPresenterEventArgs>,
          ISubscriber<RgbFilterEventArgs>,
          ISubscriber<RgbColorFilterEventArgs>,
          ISubscriber<DistributionEventArgs>,
          ISubscriber<ImageContainerEventArgs>,
          ISubscriber<FileDialogEventArgs>,
          ISubscriber<ToolbarActionEventArgs>,
          ISubscriber<RandomVariableInfoEventArgs>,
          ISubscriber<RandomVariableFunctionEventArgs>,
          ISubscriber<ZoomEventArgs>,
          ISubscriber<CloseFormEventArgs>
    {
        public async Task OnEventHandler(ApplyConvolutionFilterEventArgs e)
            => await ApplyConvolutionFilter(e).ConfigureAwait(true);

        public async Task OnEventHandler(ShowConvolutionFilterPresenterEventArgs e)
            => await ShowConvolutionFiltersMenu(e).ConfigureAwait(true);

        public async Task OnEventHandler(RgbFilterEventArgs e)
            => await ApplyRgbFilter(e).ConfigureAwait(true);

        public async Task OnEventHandler(RgbColorFilterEventArgs e)
            => await ApplyColorFilter(e).ConfigureAwait(true);

        public async Task OnEventHandler(DistributionEventArgs e)
            => await ApplyHistogramTransformation(e).ConfigureAwait(true);

        public async Task OnEventHandler(ImageContainerEventArgs e)
            => await Replace(e).ConfigureAwait(true);

        public async Task OnEventHandler(ZoomEventArgs e)
            => await Zoom(e).ConfigureAwait(true);

        public async Task OnEventHandler(CloseFormEventArgs e)
            => CloseForm();

        public async Task OnEventHandler(FileDialogEventArgs e)
        {
            switch (e.Action)
            {
                case FileDialogAction.Open:
                    await OpenImage().ConfigureAwait(true);
                    break;
                case FileDialogAction.SaveWithoutDialog:
                    await SaveImage().ConfigureAwait(true);
                    break;
                case FileDialogAction.SaveAs:
                    await SaveImageAs().ConfigureAwait(true);
                    break;

                default:
                    throw new NotImplementedException(nameof(e.Action));
            }
        }

        public async Task OnEventHandler(ToolbarActionEventArgs e)
        {
            switch (e.Action)
            {
                case ToolbarAction.Shuffle:
                    await Shuffle().ConfigureAwait(true);
                    break;
                case ToolbarAction.Undo:
                case ToolbarAction.Redo:
                    break;

                default:
                    throw new NotImplementedException(nameof(e.Action));
            }
        }

        public async Task OnEventHandler(RandomVariableInfoEventArgs e)
            => await GetRandomVariableInfo(e).ConfigureAwait(true);

        public async Task OnEventHandler(RandomVariableFunctionEventArgs e)
            => BuildFunction(e);      
    }
}
