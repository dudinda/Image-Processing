using ImageProcessing.App.DomainModel.Model.RgbFilters.Interface.Color;

namespace ImageProcessing.App.DomainModel.Model.RgbFilters.Implementation.Color.Colors
{
    /// <summary>
    /// Yellow. Implements the <see cref="IColor"/>.
    /// </summary>
    internal sealed class RGColor : IColor
    {
        /// <inheritdoc />
        public unsafe void SetPixelColor(byte* ptr)
        {
            ptr[0] = 0;
        }
    }
}
