namespace ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs
{
    /// <summary>
    /// Attach a sequence of closures to the renderer.
    /// </summary>
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
