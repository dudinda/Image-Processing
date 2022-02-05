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
            Area = new Rectangle(0, 0, bmp.Width, bmp.Height);
        }

        /// <summary>
        /// Updated bitmap.
        /// </summary>
        public Rectangle Area { get; }
    }
}
