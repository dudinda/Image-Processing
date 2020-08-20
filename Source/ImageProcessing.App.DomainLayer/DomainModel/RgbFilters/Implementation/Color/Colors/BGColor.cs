using ImageProcessing.App.DomainLayer.DomainModel.RgbFilters.Interface.Color;

namespace ImageProcessing.App.DomainLayer.DomainModel.RgbFilters.Implementation.Color.Colors
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
