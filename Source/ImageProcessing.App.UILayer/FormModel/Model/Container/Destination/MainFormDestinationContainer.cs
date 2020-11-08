using System.Drawing;

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
    }
}
