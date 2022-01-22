using System.Drawing;

namespace ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs
{
    /// <summary>
    /// A container on the main form has been updated.
    /// </summary>
    public sealed class ContainerUpdatedEventArgs : BaseEventArgs
    {
        public ContainerUpdatedEventArgs(Bitmap bmp) : base()
        {
            Bmp = bmp;
        }

        /// <summary>
        /// Updated bitmap.
        /// </summary>
        public Bitmap Bmp { get; }
    }
}
