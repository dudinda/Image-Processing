using System.Threading.Tasks;

using ImageProcessing.Core.EventAggregator.Implementation.EventArgs.Convolution;
using ImageProcessing.Core.EventAggregator.Interface.Subscriber;

namespace ImageProcessing.PresentationLayer.Presenters.Convolution
{
    partial class ConvolutionFilterPresenter : ISubscriber<ConvolutionFilterEventArgs>
    {
        public async Task OnEventHandler(ConvolutionFilterEventArgs e)
            => await ApplyConvolutionFilter(e).ConfigureAwait(true);
    }
}
