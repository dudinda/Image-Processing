using ImageProcessing.App.Common.Enums;

namespace ImageProcessing.App.DomainModel.DomainEvent.CommonArgs
{
    public sealed class ZoomEventArgs 
    {
        public ZoomEventArgs(ImageContainer container)
            => Container = container;
        
        ///<inheritdoc cref="ImageContainer"/>
        public ImageContainer Container { get; }
    }
}
