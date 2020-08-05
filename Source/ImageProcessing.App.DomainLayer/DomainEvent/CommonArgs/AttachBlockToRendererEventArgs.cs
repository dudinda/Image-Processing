using ImageProcessing.App.DomainLayer.DomainEvent.Base;

namespace ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs
{
    public sealed class AttachBlockToRendererEventArgs : BaseEventArgs
    {
        public AttachBlockToRendererEventArgs(object block)
            : base()
        {
            Block = block;
        }

        /// <summary>
        /// A pipeline functional block.
        /// </summary>
        public object Block { get; }
    }
}
