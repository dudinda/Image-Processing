using System.Drawing;

namespace ImageProcessing.App.UILayer.FormModel.Model.Zoom.DestinationContainer.Implementation
{
    internal sealed class ZoomDestinationContainer : ZoomContainer
    {
        public override double GetFactor()
            => Exposer.ZoomDstTrackBar.Factor;
       
        public override void ResetTrackBarValue(int value = 0)
        {
            Exposer.ZoomDstTrackBar.TrackBarValue = value;
            Exposer.ZoomDstTrackBar.Enabled = Exposer.DestinationImage != null;
            Exposer.ZoomDstTrackBar.Focus();
        }

        public override void SetZoomImage(Image image)
            => Exposer.ZoomDstTrackBar.ImageToZoom = image;
    }
}
