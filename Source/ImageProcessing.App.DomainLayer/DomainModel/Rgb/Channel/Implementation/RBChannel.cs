using ImageProcessing.App.DomainLayer.DomainModel.Rgb.Channel.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Rgb.Channel.Implementation
{
    /// <summary>
    /// Violet. Implements the <see cref="IChannel"/>.
    /// </summary>
    internal sealed class RBChannel : IChannel
    {
        /// <inheritdoc />
        public unsafe void GetChannel(byte* ptr)
        {
            ptr[1] = 0;
        }
    }
}
