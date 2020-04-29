using ImageProcessing.App.DomainLayer.DomainEvent.Base;

namespace ImageProcessing.App.DomainLayer.DomainEvent.ConvolutionArgs
{
    public sealed class ApplyConvolutionFilterEventArgs : BaseEventArgs
    { 
        public ApplyConvolutionFilterEventArgs(object block)
            => Block = block;

        /// <summary>
        /// A pipeline block.
        /// </summary>
        public object Block { get; }
    }
}
