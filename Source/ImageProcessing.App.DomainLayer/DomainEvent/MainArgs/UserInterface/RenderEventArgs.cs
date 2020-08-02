using ImageProcessing.App.DomainLayer.DomainEvent.Base;

namespace ImageProcessing.App.DomainLayer.DomainEvent.MainArgs
{
    public sealed class RenderEventArgs : BaseEventArgs
    {
        public RenderEventArgs(object block, object publisher)
            : base(publisher)
        {
            Block = block;
        }

        /// <summary>
        /// A pipeline functional block.
        /// </summary>
        public object Block { get; }
    }
}
