using ImageProcessing.App.DomainModel.Model.RgbFilters.Interface.Color;

namespace ImageProcessing.App.DomainModel.Model.RgbFilters.Implementation.Color.Colors
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
