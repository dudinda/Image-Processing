using System.Threading.Tasks;

using ImageProcessing.App.DomainModel.DomainEvent.ConvolutionArgs;
using ImageProcessing.Microkernel.DI.Aggregator.Subscriber;

namespace ImageProcessing.App.PresentationLayer.Presenters.Convolution
{
    internal sealed partial class ConvolutionFilterPresenter
        : ISubscriber<ConvolutionFilterEventArgs>,
          ISubscriber<ShowTooltipOnErrorEventArgs>
    {
        public async Task OnEventHandler(ConvolutionFilterEventArgs e)
            => await ApplyConvolutionFilter(e).ConfigureAwait(true);

        public Task OnEventHandler(ShowTooltipOnErrorEventArgs e)
            => ShowTooltipOnError(e);
    }
}
