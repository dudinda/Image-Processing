using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.DomainModel.DomainEvent.RgbArgs
{
    public sealed class RgbColorFilterEventArgs 
    {
        public RgbColorFilterEventArgs(RgbColors color)
            => Color = color;

        ///<inheritdoc cref="RgbColors"/>
        public RgbColors Color { get; }
    }
}
