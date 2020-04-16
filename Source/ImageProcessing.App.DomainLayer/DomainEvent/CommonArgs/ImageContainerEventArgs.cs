using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs
{
    public sealed class ImageContainerEventArgs
    {
        public ImageContainerEventArgs(ImageContainer container)
            => Container = container;
       
        ///<inheritdoc cref="ImageContainer"/>
        public ImageContainer Container { get; }
    }
}
