namespace ImageProcessing.App.PresentationLayer.DomainEvents.ColorMatrixArgs
{
    /// <summary>
    /// A checkbox for a custom color matrix has been changed.
    /// </summary>
    public sealed class CustomColorMatrixEventArgs : BaseEventArgs
    {
        public CustomColorMatrixEventArgs(bool useCustom) : base()
        {
            UseCustom = useCustom;
        }

        /// <summary>
        /// Use a custom color matrix.
        /// </summary>
        public bool UseCustom { get; }
    }
}
