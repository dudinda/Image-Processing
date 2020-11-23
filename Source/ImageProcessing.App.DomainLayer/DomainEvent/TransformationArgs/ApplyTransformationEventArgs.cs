namespace ImageProcessing.App.DomainLayer.DomainEvent.TransformationArgs
{
    /// <summary>
    /// Apply an affine transformation.
    /// </summary>
    public sealed class ApplyTransformationEventArgs : BaseEventArgs
    {
        public ApplyTransformationEventArgs((string, string) parms)
        {
            Parameters = parms;
        }

        public (string X, string Y) Parameters { get; }
    }
}
