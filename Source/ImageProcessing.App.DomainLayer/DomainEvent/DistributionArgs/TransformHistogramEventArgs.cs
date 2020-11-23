namespace ImageProcessing.App.DomainLayer.DomainEvent.DistributionArgs
{
    /// <summary>
    /// Transform a histogram of an image with the specified parameters.
    /// </summary>
    public sealed class TransformHistogramEventArgs : BaseEventArgs
    {
        public TransformHistogramEventArgs((string, string) parms) : base()
        {
            Parameters = parms;
        }

        /// <summary>
        /// Parameters of the specified <see cref="PrDistribution"/>.
        /// </summary>
        public (string, string) Parameters { get; }
    }
}
