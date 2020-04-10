namespace ImageProcessing.DomainModel.DomainEvent.ConvolutionArgs
{
    public sealed class ApplyConvolutionFilterEventArgs 
    {
        public ApplyConvolutionFilterEventArgs(object block)
            => Block = block;

        /// <summary>
        /// A pipeline block.
        /// </summary>
        public object Block { get; }
    }
}
