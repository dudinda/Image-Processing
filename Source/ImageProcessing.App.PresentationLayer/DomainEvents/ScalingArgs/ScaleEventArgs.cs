namespace ImageProcessing.App.PresentationLayer.DomainEvents.ScalingArgs
{
    /// <summary>
    /// Press a button to scale.
    /// </summary>
    public sealed class ScaleEventArgs : BaseEventArgs
    {
        public ScaleEventArgs((string, string) parms)
        {
            Parameters = parms;
        }

        public (string X, string Y) Parameters { get; }
    }
}
