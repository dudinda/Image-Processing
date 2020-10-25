using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs
{
    public sealed class ContainerUpdatedEventArgs
    {
        public ContainerUpdatedEventArgs(
            ImageContainer container, Bitmap bmp)
        {
            Container = container;
            Bmp = bmp;
        }

        public Bitmap Bmp { get; }
        public ImageContainer Container { get; }
    }
}
