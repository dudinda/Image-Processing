namespace ImageProcessing.App.Presentation.DomainEvents.CommonArgs
{
    public class AttachBlockToPaintEventArgs : BaseEventArgs
    {
        public AttachBlockToPaintEventArgs(object block) : base()
        {
            Block = block;
        }

        /// <summary>
        /// A pipeline functional block.
        /// </summary>
        public object Block { get; }
    }
}
