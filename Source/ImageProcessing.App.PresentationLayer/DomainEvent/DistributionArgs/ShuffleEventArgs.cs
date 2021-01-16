namespace ImageProcessing.App.DomainLayer.DomainEvent.DistributionArgs
{
    /// <summary>
    /// Perform the Fisher–Yates shuffle on a selected bitmap.
    /// </summary>
    public sealed class ShuffleEventArgs : BaseEventArgs
    { 
        public ShuffleEventArgs() : base()
        {

        }
    }
}
