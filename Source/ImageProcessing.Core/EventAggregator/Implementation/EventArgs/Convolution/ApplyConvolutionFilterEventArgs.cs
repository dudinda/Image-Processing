using ImageProcessing.Core.EventAggregator.Interface.EventArgs;
using ImageProcessing.Core.Pipeline;
using ImageProcessing.Core.Pipeline.Block.Implementation;

namespace ImageProcessing.Core.EventAggregator.Implementation.EventArgs.Convolution
{
    public class ApplyConvolutionFilterEventArgs : IBaseEventArgs<IPipelineBlock>
    {
        public ApplyConvolutionFilterEventArgs(IPipelineBlock arg)
        {
            Arg = arg;
        }

        ///<inheritdoc cref="PipelineBlock{Bitmap}"/>
        public IPipelineBlock Arg { get; }
    }
}
