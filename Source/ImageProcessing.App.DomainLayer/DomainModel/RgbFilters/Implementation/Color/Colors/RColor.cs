using ImageProcessing.App.DomainLayer.DomainModel.RgbFilters.Interface.Color;

namespace ImageProcessing.App.DomainLayer.DomainModel.RgbFilters.Implementation.Color.Colors
{
    /// <summary>
    /// Red. Implements the <see cref="IColor"/>.
    /// </summary>
    internal sealed class RColor : IColor
    {
        /// <inheritdoc/>
        public unsafe void SetPixelColor(byte* ptr)
        {
            ptr[0] = 0;
            ptr[1] = 0;
        }
    }
}
