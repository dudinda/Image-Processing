using ImageProcessing.App.DomainModel.Model.RgbFilters.Interface.Color;

namespace ImageProcessing.App.DomainModel.Model.RgbFilters.Implementation.Color.Colors
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
