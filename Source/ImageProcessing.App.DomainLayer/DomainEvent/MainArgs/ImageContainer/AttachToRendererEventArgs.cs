using ImageProcessing.App.DomainLayer.DomainEvent.Base;

namespace ImageProcessing.App.DomainLayer.DomainEvent.MainArgs
{
    public sealed class AttachToRendererEventArgs : BaseEventArgs
    {
        public AttachToRendererEventArgs(object block)
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
