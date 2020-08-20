using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.DomainLayer.DomainEvent.RgbArgs
{
    public sealed class ApplyRgbColorFilterEventArgs : BaseEventArgs
    {
        public ApplyRgbColorFilterEventArgs(RgbColors color, object publisher)
            : base(publisher)
        {
            Color = color;
        }

        ///<inheritdoc cref="RgbColors"/>
        public RgbColors Color { get; }
    }
}
