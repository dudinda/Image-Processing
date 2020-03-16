using ImageProcessing.Core.Pipeline;

namespace ImageProcessing.DomainModel.DomainEvent.ConvolutionArgs
{
    public sealed class ApplyConvolutionFilterEventArgs 
    {
        public ApplyConvolutionFilterEventArgs(IPipelineBlock block)
            => Block = block;

        ///<inheritdoc cref="PipelineBlock{Bitmap}"/>
        public IPipelineBlock Block { get; }
    }
}
