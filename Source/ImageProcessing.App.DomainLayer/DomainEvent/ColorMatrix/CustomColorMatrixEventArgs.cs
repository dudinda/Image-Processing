namespace ImageProcessing.App.DomainLayer.DomainEvent.ColorMatrix
{
    public sealed class CustomColorMatrixEventArgs : BaseEventArgs
    {
        public CustomColorMatrixEventArgs(bool useCustom)
        {
            UseCustom = useCustom;
        }

        public bool UseCustom { get; }
    }
}
