using ImageProcessing.App.Domain.Models.Rgb;

namespace ImageProcessing.App.Domain.Models.Rgb.Channel.Implementation
{
    /// <summary>
    /// Blue. Implements the <see cref="IChannel"/>.
    /// </summary>
    public sealed class BChannel : IChannel
    {
        /// <inheritdoc/>
        public unsafe void GetChannel(byte* ptr)
        {
            ptr[1] = 0;
            ptr[2] = 0;
        }   
    }
}
