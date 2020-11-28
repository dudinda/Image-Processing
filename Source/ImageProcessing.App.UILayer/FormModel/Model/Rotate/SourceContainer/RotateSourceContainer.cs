namespace ImageProcessing.App.UILayer.FormModel.Model.Rotate.SourceContainer.Implementation
{
    internal sealed class RotateSourceContainer : RotateContainer
    {
        public override double GetFactor()
            => Exposer.RotationSrcTrackBar.Factor;

        public override void ResetTrackBarValue(int value = 0)
        {
            Exposer.RotationSrcTrackBar.TrackBarValue = value;
            Exposer.RotationSrcTrackBar.Enabled = Exposer.SourceImage != null;
            Exposer.RotationSrcTrackBar.Focus();
        }

    }
}
