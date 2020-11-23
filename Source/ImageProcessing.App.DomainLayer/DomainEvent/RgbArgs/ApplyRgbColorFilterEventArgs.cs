using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.DomainLayer.DomainEvent.RgbArgs
{
    /// <summary>
    /// Filter bitmap by the specified channel.
    /// </summary>
    public sealed class ApplyRgbColorFilterEventArgs : BaseEventArgs
    {
        public ApplyRgbColorFilterEventArgs(RgbColors color): base()
        {
            Color = color;
        }

        ///<inheritdoc cref="RgbColors"/>
        public RgbColors Color { get; }
    }
}
