using ImageProcessing.App.DomainLayer.Models.Rgb.Channel.Interface;

namespace ImageProcessing.App.DomainLayer.Models.Rgb.Channel.Implementation
{
    /// <summary>
    /// Green. Implements the <see cref="IChannel"/>.
    /// </summary>
    public sealed class GChannel : IChannel
    {
        /// <inheritdoc />
        public unsafe void GetChannel(byte* ptr)
        {
            ptr[0] = 0;
            ptr[2] = 0;
        }
    }
}
