namespace ImageProcessing.App.Presentation.DomainEvents.DistributionArgs
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
