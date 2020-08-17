using System.Drawing;

using ImageProcessing.App.UILayer.FormCommands.Main.Container.Destination.Interface;
using ImageProcessing.App.UILayer.FormExposers.Main;

namespace ImageProcessing.App.UILayer.FormCommands.Main.Container.Destination.Implementation
{
    internal class MainFormDestinationContainerCommand : IMainFormDestinationContainerCommand
    {
        private IMainFormExposer _exposer
            = null!;

        public void OnElementExpose(IMainFormExposer exposer)
            => _exposer = exposer;
      
        public Image? GetCopy()
            => _exposer.DstImageCopy;

        public bool ImageIsDefault()
            => _exposer.DstImageCopy == _exposer.DefaultImage;

        public void Refresh()
            => _exposer.DestinationBox.Refresh();

        public void ResetTrackBarValue(int value = 0)
        {
            _exposer.ZoomDstTrackBar.TrackBarValue = value;
            _exposer.ZoomDstTrackBar.Enabled = _exposer.DestinationImage != null;
            _exposer.ZoomDstTrackBar.Focus();
        }

        public void SetCopy(Image image)
            => _exposer.DstImageCopy = image;

        public void SetImage(Image image)
            => _exposer.DestinationImage = image;
       
        public void SetZoomImage(Image image)
            => _exposer.ZoomDstTrackBar.ImageToZoom = image;

        public Image ZoomImage()
            => _exposer.ZoomDstTrackBar.Zoom();
    }
}
