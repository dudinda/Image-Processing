using ImageProcessing.Common.Enums;

namespace ImageProcessing.DomainModel.DomainEvent.CommonArgs
{
    public sealed class ZoomEventArgs 
    {
        public ZoomEventArgs(ImageContainer container)
            => Container = container;
        
        ///<inheritdoc cref="ImageContainer"/>
        public ImageContainer Container { get; }
    }
}
