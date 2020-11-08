using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.DomainLayer.DomainEvent.SettingsArgs
{
    public sealed class ChangeScalingEventArgs : BaseEventArgs
    {
        public ChangeScalingEventArgs(ScalingMethod scaling, object publisher)
          : base(publisher)
        {
            Scaling = scaling;
        }

        public ScalingMethod Scaling { get; }
    }
}
