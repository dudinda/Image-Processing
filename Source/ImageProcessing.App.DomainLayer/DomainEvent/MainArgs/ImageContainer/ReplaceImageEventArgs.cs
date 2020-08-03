using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.Base;

namespace ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs
{
    public sealed class ReplaceImageEventArgs : BaseEventArgs
    {
        public ReplaceImageEventArgs(ImageContainer container) : base()
            => Container = container;
       
        ///<inheritdoc cref="ImageContainer"/>
        public ImageContainer Container { get; }
    }
}
