using ImageProcessing.App.DomainLayer.DomainModel.Rgb.Color.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Rgb.Color.Implementation
{
    /// <summary>
    /// Blue-green. Implements the <see cref="IColor"/>.
    /// </summary>
    internal sealed class BGColor : IColor
    {
        /// <inheritdoc/>
        public unsafe void SetPixelColor(byte* ptr)
        {
            ptr[2] = 0;
        }
    }
}
