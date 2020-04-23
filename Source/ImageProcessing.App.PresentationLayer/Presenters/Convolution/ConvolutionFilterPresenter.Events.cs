using ImageProcessing.App.DomainLayer.DomainEvent.ConvolutionArgs;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;

namespace ImageProcessing.App.PresentationLayer.Presenters.Convolution
{
    internal sealed partial class ConvolutionFilterPresenter
        : ISubscriber<ConvolutionFilterEventArgs>,
          ISubscriber<ShowTooltipOnErrorEventArgs>
    {
        public void OnEventHandler(ConvolutionFilterEventArgs e)
            => ApplyConvolutionFilter(e);

        public void OnEventHandler(ShowTooltipOnErrorEventArgs e)
            => ShowTooltipOnError(e);
    }
}
