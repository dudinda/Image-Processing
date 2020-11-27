using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.DomainLayer.DomainEvent.RgbArgs
{
    /// <summary>
    /// Filter bitmap by the specified channel.
    /// </summary>
    public sealed class ApplyRgbChannelFilterEventArgs : BaseEventArgs
    {
        public ApplyRgbChannelFilterEventArgs(RgbChannels channel): base()
        {
            Channel = channel;
        }

        ///<inheritdoc cref="RgbChannels"/>
        public RgbChannels Channel { get; }
    }
}
