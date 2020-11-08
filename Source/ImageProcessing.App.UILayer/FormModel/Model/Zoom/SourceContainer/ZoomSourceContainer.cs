using System.Drawing;

namespace ImageProcessing.App.UILayer.FormModel.Model.Zoom.SourceContainer.Implementation
{
    internal sealed class ZoomSourceContainer : ZoomContainer
    {
        public override void ResetTrackBarValue(int value = 0)
        {
            Exposer.ZoomSrcTrackBar.TrackBarValue = value;
            Exposer.ZoomSrcTrackBar.Enabled = Exposer.SourceImage != null;
            Exposer.ZoomSrcTrackBar.Focus();
        }

        public override void SetZoomImage(Image image)
            => Exposer.ZoomSrcTrackBar.ImageToZoom = image;
    }
}
