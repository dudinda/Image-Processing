using System.Threading.Tasks;

using ImageProcessing.Core.EventAggregator.Interface.Subscriber;
using ImageProcessing.DomainModel.EventArgs.Convolution;

namespace ImageProcessing.Presentation.Presenters.Convolution
{
	partial class ConvolutionFilterPresenter : ISubscriber<ConvolutionFilterEventArgs>
    {
        public async Task OnEventHandler(ConvolutionFilterEventArgs e)
            => await ApplyConvolutionFilter(e).ConfigureAwait(true);
        
    }
}
