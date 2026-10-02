using ImageProcessing.App.Domain.Models.Rgb;

namespace ImageProcessing.App.Domain.Models.Rgb.Channel.Implementation
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
