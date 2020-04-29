using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.Base;

namespace ImageProcessing.App.DomainLayer.DomainEvent.RgbArgs
{
    public sealed class RgbColorFilterEventArgs : BaseEventArgs
    {
        public RgbColorFilterEventArgs(RgbColors color)
            => Color = color;

        ///<inheritdoc cref="RgbColors"/>
        public RgbColors Color { get; }
    }
}
