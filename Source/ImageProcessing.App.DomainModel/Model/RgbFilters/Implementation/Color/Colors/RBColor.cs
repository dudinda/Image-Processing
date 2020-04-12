using ImageProcessing.App.DomainModel.Model.RgbFilters.Interface.Color;

namespace ImageProcessing.App.DomainModel.Model.RgbFilters.Implementation.Color.Colors
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
