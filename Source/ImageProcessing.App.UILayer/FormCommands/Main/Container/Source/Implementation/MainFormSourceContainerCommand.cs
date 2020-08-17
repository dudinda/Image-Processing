using System.Drawing;

using ImageProcessing.App.UILayer.FormCommands.Main.Container.Source.Interface;
using ImageProcessing.App.UILayer.FormExposers.Main;

namespace ImageProcessing.App.UILayer.FormCommands.Main.Container.Source.Implementation
{
    internal class MainFormSourceContainerCommand : IMainFormSourceContainerCommand
    {
        private IMainFormExposer _exposer
            = null!;

        public void OnElementExpose(IMainFormExposer exposer)
            => _exposer = exposer;
      
        public Image? GetCopy()
            => _exposer.SrcImageCopy;

        public bool ImageIsDefault()
            => _exposer.SrcImageCopy == _exposer.DefaultImage;

        public void Refresh()
            => _exposer.SourceBox.Refresh();

        public void ResetTrackBarValue(int value = 0)
        {
            _exposer.ZoomSrcTrackBar.TrackBarValue = value;
            _exposer.ZoomSrcTrackBar.Enabled = _exposer.SourceImage != null;
            _exposer.ZoomSrcTrackBar.Focus();
        }

        public void SetCopy(Image image)
            => _exposer.SrcImageCopy = image;

        public void SetImage(Image image)
            => _exposer.SourceImage = image;
       
        public void SetZoomImage(Image image)
            => _exposer.ZoomSrcTrackBar.ImageToZoom = image;

        public Image ZoomImage()
            => _exposer.ZoomSrcTrackBar.Zoom();
    }
}
