using ImageProcessing.App.DomainLayer.DomainModel.Rgb.Channel.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Rgb.Channel.Implementation
{
    /// <summary>
    /// Blue-green. Implements the <see cref="IChannel"/>.
    /// </summary>
    internal sealed class BGChannel : IChannel
    {
        /// <inheritdoc/>
        public unsafe void GetChannel(byte* ptr)
        {
            ptr[2] = 0;
        }
    }
}
