namespace ImageProcessing.App.DomainLayer.DomainEvent.DistributionArgs
{
    public sealed class ShuffleEventArgs : BaseEventArgs
    { 
        public ShuffleEventArgs(object publisher)
            : base(publisher)
        {

        }
    }
}
