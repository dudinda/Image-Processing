using ImageProcessing.App.DomainLayer.DomainModel.Rgb.Channel.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Rgb.Channel.Implementation
{
    /// <summary>
    /// The source color. Implements the <see cref="IChannel"/>. 
    /// </summary>
    internal sealed class RGBChannel : IChannel
    {
        /// <inheritdoc />
        public unsafe void GetChannel(byte* ptr)
        {

        }
    }
}
