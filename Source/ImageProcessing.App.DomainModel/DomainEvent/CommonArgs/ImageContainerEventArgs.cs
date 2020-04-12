using ImageProcessing.App.Common.Enums;

namespace ImageProcessing.App.DomainModel.DomainEvent.CommonArgs
{
    public sealed class ImageContainerEventArgs
    {
        public ImageContainerEventArgs(ImageContainer container)
            => Container = container;
       
        ///<inheritdoc cref="ImageContainer"/>
        public ImageContainer Container { get; }
    }
}
