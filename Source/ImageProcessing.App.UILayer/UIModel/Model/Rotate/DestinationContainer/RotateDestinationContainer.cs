namespace ImageProcessing.App.UILayer.FormModel.Model.Rotate.DestinationContainer.Implementation
{
    internal sealed class RotateDestinationContainer : RotateContainer
    {
        public override double GetFactor()
            => Exposer.RotationDstTrackBar.Factor;
       
        public override void ResetTrackBarValue(int value = 0)
        {
            Exposer.RotationDstTrackBar.TrackBarValue = value;
            Exposer.RotationDstTrackBar.Enabled = Exposer.DestinationImage != null;
            Exposer.RotationDstTrackBar.Focus();
        }
    }
}
