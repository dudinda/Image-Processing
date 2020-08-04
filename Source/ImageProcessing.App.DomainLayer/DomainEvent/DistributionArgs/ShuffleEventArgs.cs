using ImageProcessing.App.DomainLayer.DomainEvent.Base;

namespace ImageProcessing.App.DomainLayer.DomainEvent.ToolbarArgs
{
    public sealed class ShuffleEventArgs : BaseEventArgs
    { 
        public ShuffleEventArgs(object publisher)
            : base(publisher)
        {

        }
    }
}
