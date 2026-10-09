namespace ImageProcessing.App.Domain.Models.Rgb.Channel.Implementation
{
    /// <summary>
    /// Red. Implements the <see cref="IChannel"/>.
    /// </summary>
    public sealed class RChannel : IChannel
    {
        /// <inheritdoc/>
        public unsafe void GetChannel(byte* ptr)
        {
            ptr[0] = 0;
            ptr[1] = 0;
        }
    }
}
