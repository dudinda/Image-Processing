using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.DomainLayer.DomainEvent.MainArgs.Container
{
    public sealed class ZoomEventArgs : BaseEventArgs
    {
        public ZoomEventArgs(ImageContainer container) : base()
            => Container = container;
        
        ///<inheritdoc cref="ImageContainer"/>
        public ImageContainer Container { get; }
    }
}
