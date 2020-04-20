using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.ConvolutionArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.DistributionArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.FileDialogArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.RgbArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.ToolbarArgs;
using ImageProcessing.App.DomainLayer.DomainEvents.QualityMeasureArgs;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;

namespace ImageProcessing.App.PresentationLayer.Presenters.Main
{
    public sealed partial class MainPresenter
        : ISubscriber<ApplyConvolutionFilterEventArgs>,
          ISubscriber<ShowConvolutionFilterPresenterEventArgs>,
          ISubscriber<ShowQualityMeasureEventArgs>,
          ISubscriber<RgbFilterEventArgs>,
          ISubscriber<RgbColorFilterEventArgs>,
          ISubscriber<DistributionEventArgs>,
          ISubscriber<ImageContainerEventArgs>,
          ISubscriber<RandomVariableInfoEventArgs>,
          ISubscriber<RandomVariableFunctionEventArgs>,
          ISubscriber<ZoomEventArgs>,
          ISubscriber<CloseFormEventArgs>,
          ISubscriber<OpenFileDialogEventArgs>,
          ISubscriber<SaveAsFileDialogEventArgs>,
          ISubscriber<SaveWithoutFileDialogEventArgs>,
          ISubscriber<ShuffleEventArgs>
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
            => await CloseForm(e).ConfigureAwait(true);

        public async Task OnEventHandler(RandomVariableInfoEventArgs e)
            => await GetRandomVariableInfo(e).ConfigureAwait(true);

        public async Task OnEventHandler(RandomVariableFunctionEventArgs e)
            => await BuildFunction(e).ConfigureAwait(true);

        public async Task OnEventHandler(SaveAsFileDialogEventArgs e)
            => await SaveImageAs(e).ConfigureAwait(true);
        
        public async Task OnEventHandler(OpenFileDialogEventArgs e)
            => await OpenImage(e).ConfigureAwait(true);

        public async Task OnEventHandler(SaveWithoutFileDialogEventArgs e)
            => await SaveImage(e).ConfigureAwait(true);

        public async Task OnEventHandler(ShuffleEventArgs e)
            => await Shuffle(e).ConfigureAwait(true);

        public async Task OnEventHandler(ShowQualityMeasureEventArgs e)
            => await ShowQualityMeasureForm(e).ConfigureAwait(true);
    }
}
