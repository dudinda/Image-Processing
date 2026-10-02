using ImageProcessing.App.DomainLayer.Models.Rgb.Channel.Interface;

namespace ImageProcessing.App.DomainLayer.Models.Rgb.Channel.Implementation
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
