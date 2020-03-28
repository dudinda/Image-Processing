using System.Threading.Tasks;

using ImageProcessing.Core.EventAggregator.Interface.Subscriber;
using ImageProcessing.DomainModel.DomainEvent.ConvolutionArgs;

namespace ImageProcessing.PresentationLayer.Presenters.Convolution
{
    internal sealed partial class ConvolutionFilterPresenter : ISubscriber<ConvolutionFilterEventArgs>,
                                               ISubscriber<ShowTooltipOnErrorEventArgs>
    {
        public async Task OnEventHandler(ConvolutionFilterEventArgs e)
            => await ApplyConvolutionFilter(e).ConfigureAwait(true);

        public Task OnEventHandler(ShowTooltipOnErrorEventArgs e)
            => ShowTooltipOnError(e);
    }
}
