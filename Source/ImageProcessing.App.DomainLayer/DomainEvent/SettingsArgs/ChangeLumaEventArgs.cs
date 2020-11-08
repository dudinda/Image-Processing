using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.DomainLayer.DomainEvent.SettingsArgs
{
    public sealed class ChangeLumaEventArgs : BaseEventArgs
    {
        public ChangeLumaEventArgs(Luma rec, object publisher)
            : base(publisher)
        {
            Rec = rec;
        }

        public Luma Rec { get; }
    }
}
