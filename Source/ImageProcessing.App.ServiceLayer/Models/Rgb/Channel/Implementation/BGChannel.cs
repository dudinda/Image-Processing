using ImageProcessing.App.ServiceLayer.Models.Rgb;

namespace ImageProcessing.App.ServiceLayer.Models.Rgb.Channel.Implementation
{
    /// <summary>
    /// Blue-green. Implements the <see cref="IChannel"/>.
    /// </summary>
    public sealed class BGChannel : IChannel
    {
        /// <inheritdoc/>
        public unsafe void GetChannel(byte* ptr)
        {
            ptr[2] = 0;
        }
    }
}
