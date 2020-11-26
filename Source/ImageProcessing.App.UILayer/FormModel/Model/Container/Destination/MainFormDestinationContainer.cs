using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.App.UILayer.FormModel.Model.Container;

namespace ImageProcessing.App.UILayer.FormCommands.Main.Container.Destination.Implementation
{
    internal sealed class MainFormDestinationContainer : MainFormContainer
    {
        public override Image? GetCopy()
            => Exposer.DstImageCopy;

        public override bool ImageIsDefault()
            => Exposer.DstImageCopy == Exposer.DefaultImage;

        public override void Refresh()
            => Exposer.DestinationBox.Refresh();

        public override void SetCopy(Image image)
            => Exposer.DstImageCopy = image;

        public override void SetImage(Image image)
            => Exposer.DestinationImage = image;

        public override void SetImageCenter(Size size)
        {
            if (Exposer.DestinationBox.Parent is Panel panel)
            {
                var newX = (panel.ClientSize.Width - size.Width) / 2;
                var newY = (panel.ClientSize.Height - size.Height) / 2;

                var location = new Point(0, 0);

                if (newX > 0 && newY > 0)
                {
                    (location.X, location.Y) = (newX, newY);
                }

                if (newX > 0 && newY < 0)
                {
                    (location.X, location.Y) = (newX, 0);
                }

                if (newX < 0 && newY > 0)
                {
                    (location.X, location.Y) = (newX, newY);
                }

                Exposer.DestinationBox.Location = location;
            }
        }
    }
}
