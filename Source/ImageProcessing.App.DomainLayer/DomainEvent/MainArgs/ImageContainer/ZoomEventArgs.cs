using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.Base;

namespace ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs
{
    public sealed class ZoomEventArgs : BaseEventArgs
    {
        public ZoomEventArgs(ImageContainer container) : base()
            => Container = container;
        
        ///<inheritdoc cref="ImageContainer"/>
        public ImageContainer Container { get; }
    }
}