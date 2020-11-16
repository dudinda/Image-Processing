namespace ImageProcessing.App.DomainLayer.DomainEvent.ColorMatrix
{
    public sealed class CustomColorMatrixEventArgs : BaseEventArgs
    {
        public CustomColorMatrixEventArgs(bool useCustom) : base()
        {
            UseCustom = useCustom;
        }

        public bool UseCustom { get; }
    }
}
