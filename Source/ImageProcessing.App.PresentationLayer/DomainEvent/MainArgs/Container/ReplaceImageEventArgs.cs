using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.DomainLayer.DomainEvent.MainArgs.Container
{
    /// <summary>
    /// Replace an image on the specified <see cref="ImageContainer"/>.
    /// </summary>
    public sealed class ReplaceImageEventArgs : BaseEventArgs
    {
        public ReplaceImageEventArgs(ImageContainer container) : base()
        {
            Container = container;
        }
       
        ///<inheritdoc cref="ImageContainer"/>
        public ImageContainer Container { get; }
    }
}
