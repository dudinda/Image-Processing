using System.Drawing;

using ImageProcessing.App.PresentationLayer.Code.Enums;

namespace ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs
{
    /// <summary>
    /// A container on the main form has been updated.
    /// </summary>
    public sealed class ContainerUpdatedEventArgs
    {
        public ContainerUpdatedEventArgs(
            ImageContainer container, Bitmap bmp) : base()
        {
            Container = container;
            Bmp = bmp;
        }

        /// <summary>
        /// Updated bitmap.
        /// </summary>
        public Bitmap Bmp { get; }

        /// <summary>
        /// Updated container. 
        /// </summary>
        public ImageContainer Container { get; }
    }
}
