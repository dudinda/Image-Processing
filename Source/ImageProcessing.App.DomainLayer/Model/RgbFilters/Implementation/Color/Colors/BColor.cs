using ImageProcessing.App.DomainLayer.Model.RgbFilters.Interface.Color;

namespace ImageProcessing.App.DomainLayer.Model.RgbFilters.Implementation.Color.Colors
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
