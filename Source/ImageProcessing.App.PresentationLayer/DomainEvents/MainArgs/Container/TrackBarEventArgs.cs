using ImageProcessing.App.PresentationLayer.Code.Enums;

namespace ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Container
{
    /// <summary>
    /// Zoom the specified <see cref="ImageContainer"/>.
    /// </summary>
    public sealed class TrackBarEventArgs : BaseEventArgs
    {
        public TrackBarEventArgs(ImageContainer container) : base()
        {
            Container = container;

        }
        
        ///<inheritdoc cref="ImageContainer"/>
        public ImageContainer Container { get; }
    }
}
