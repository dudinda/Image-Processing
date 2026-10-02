using ImageProcessing.App.Domain.Models.Rgb;

namespace ImageProcessing.App.Domain.Models.Rgb.Channel.Implementation
{
    /// <summary>
    /// The source color. Implements the <see cref="IChannel"/>. 
    /// </summary>
    public sealed class RGBChannel : IChannel
    {
        /// <inheritdoc />
        public unsafe void GetChannel(byte* ptr)
        {

        }
    }
}
