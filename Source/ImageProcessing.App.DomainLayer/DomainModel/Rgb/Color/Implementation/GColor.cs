using ImageProcessing.App.DomainLayer.DomainModel.Rgb.Color.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Rgb.Color.Implementation
{
    /// <summary>
    /// Green. Implements the <see cref="IColor"/>.
    /// </summary>
    internal sealed class GColor : IColor
    {
        /// <inheritdoc />
        public unsafe void SetPixelColor(byte* ptr)
        {
            ptr[0] = 0;
            ptr[2] = 0;
        }
    }
}
