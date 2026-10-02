using ImageProcessing.App.ServiceLayer.Models.Rgb;

namespace ImageProcessing.App.ServiceLayer.Models.Rgb.Channel.Implementation
{
    /// <summary>
    /// Violet. Implements the <see cref="IChannel"/>.
    /// </summary>
    public sealed class RBChannel : IChannel
    {
        /// <inheritdoc />
        public unsafe void GetChannel(byte* ptr)
        {
            ptr[1] = 0;
        }
    }
}
