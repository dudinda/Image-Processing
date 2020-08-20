using ImageProcessing.App.DomainLayer.DomainModel.RgbFilters.Interface.Color;

namespace ImageProcessing.App.DomainLayer.DomainModel.RgbFilters.Implementation.Color.Colors
{
    /// <summary>
    /// Violet. Implements the <see cref="IColor"/>.
    /// </summary>
    internal sealed class RBColor : IColor
    {
        /// <inheritdoc />
        public unsafe void SetPixelColor(byte* ptr)
        {
            ptr[1] = 0;
        }
    }
}
