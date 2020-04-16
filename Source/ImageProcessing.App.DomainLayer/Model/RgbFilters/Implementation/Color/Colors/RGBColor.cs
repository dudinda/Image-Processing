using ImageProcessing.App.DomainLayer.Model.RgbFilters.Interface.Color;

namespace ImageProcessing.App.DomainLayer.Model.RgbFilters.Implementation.Color.Colors
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
