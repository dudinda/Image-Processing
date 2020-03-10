using System.Drawing;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EventAggregator.Interface.EventArgs;
using ImageProcessing.Core.Pipeline.Block.Implementation;

namespace ImageProcessing.Core.EventAggregator.Implementation.EventArgs.Convolution
{
    public class ApplyConvolutionFilterEventArgs : IBaseEventArgs<PipelineBlock>
    {
        public ApplyConvolutionFilterEventArgs(PipelineBlock arg)
        {
            Arg = arg;
        }

        ///<inheritdoc cref="PipelineBlock{Bitmap}"/>
        public PipelineBlock Arg { get; }
    }
}
