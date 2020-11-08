using ImageProcessing.App.DomainLayer.DomainModel.Rgb.Color.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Rgb.Color.Implementation
{
    /// <summary>
    /// Blue. Implements the <see cref="IColor"/>.
    /// </summary>
    internal sealed class BColor : IColor
    {
        /// <inheritdoc/>
        public unsafe void SetPixelColor(byte* ptr)
        {
            ptr[1] = 0;
            ptr[2] = 0;
        }   
    }
}
