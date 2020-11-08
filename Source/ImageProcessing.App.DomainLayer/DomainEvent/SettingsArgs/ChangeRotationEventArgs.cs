using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.DomainLayer.DomainEvent.SettingsArgs
{
    public sealed class ChangeRotationEventArgs : BaseEventArgs
    {
        public ChangeRotationEventArgs(RotationMethod rotation, object publisher)
           : base(publisher)
        {
            Rotation = rotation;
        }

        public RotationMethod Rotation { get; }
    }
}
