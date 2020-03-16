using ImageProcessing.Common.Enums;

namespace ImageProcessing.DomainModel.DomainEvent.RgbArgs
{
    public sealed class RgbColorFilterEventArgs 
    {
        public RgbColorFilterEventArgs(RgbColors color)
            => Color = color;

        ///<inheritdoc cref="RgbColors"/>
        public RgbColors Color { get; }
    }
}
