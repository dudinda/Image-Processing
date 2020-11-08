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
    }
}
