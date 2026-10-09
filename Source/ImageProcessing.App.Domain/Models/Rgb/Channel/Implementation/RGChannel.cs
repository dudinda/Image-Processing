namespace ImageProcessing.App.Domain.Models.Rgb.Channel.Implementation
{
    /// <summary>
    /// Yellow. Implements the <see cref="IChannel"/>.
    /// </summary>
    public sealed class RGChannel : IChannel
    {
        /// <inheritdoc />
        public unsafe void GetChannel(byte* ptr)
        {
            ptr[0] = 0;
        }
    }
}
