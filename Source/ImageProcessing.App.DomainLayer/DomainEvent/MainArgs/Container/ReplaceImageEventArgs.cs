using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.DomainLayer.DomainEvent.MainArgs.Container
{
    public sealed class ReplaceImageEventArgs : BaseEventArgs
    {
        public ReplaceImageEventArgs(ImageContainer container) : base()
            => Container = container;
       
        ///<inheritdoc cref="ImageContainer"/>
        public ImageContainer Container { get; }
    }
}
