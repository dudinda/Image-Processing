using ImageProcessing.App.DomainLayer.Code.Enums;

namespace ImageProcessing.App.PresentationLayer.DomainEvents.RgbArgs
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
