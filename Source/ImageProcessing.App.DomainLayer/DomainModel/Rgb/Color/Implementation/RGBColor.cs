using ImageProcessing.App.DomainLayer.DomainModel.Rgb.Color.Interface;

namespace ImageProcessing.App.DomainLayer.DomainModel.Rgb.Color.Implementation
{
    /// <summary>
    /// The source color. Implements the <see cref="IColor"/>. 
    /// </summary>
    internal sealed class RGBColor : IColor
    {
        /// <inheritdoc />
        public unsafe void SetPixelColor(byte* ptr)
        {

        }
    }
}
