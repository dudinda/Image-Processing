using System.Drawing;

using ImageProcessing.App.UILayer.FormModel.Model.Container;

namespace ImageProcessing.App.UILayer.FormCommands.Main.Container.Source.Implementation
{
    internal sealed class MainFormSourceContainer : MainFormContainer
    {
        public override Image? GetCopy()
            => Exposer.SrcImageCopy;

        public override bool ImageIsDefault()
            => Exposer.SrcImageCopy == Exposer.DefaultImage;

        public override void Refresh()
            => Exposer.SourceBox.Refresh();

        public override void SetCopy(Image image)
            => Exposer.SrcImageCopy = image;

        public override void SetImage(Image image)
            => Exposer.SourceImage = image;

        public override void SetImageCenter(Size size)
        {
            var client = Exposer.SourceBox.Parent.ClientSize;

            var newX = (client.Width - size.Width) / 2;
            var newY = (client.Height - size.Height) / 2;

            Exposer.SourceBox.Location = new Point(newX, newY);
        }
    }
}
