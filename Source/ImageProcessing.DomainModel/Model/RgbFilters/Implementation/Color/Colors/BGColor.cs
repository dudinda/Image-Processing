using ImageProcessing.DomainModel.Model.RgbFilters.Interface.Color;

namespace ImageProcessing.DomainModel.Model.RgbFilters.Implementation.Color.Colors
{
    internal sealed class BGColor : IColor
    {
        public unsafe void SetPixelColor(byte* ptr)
        {
            ptr[2] = 0;
        }
    }
}
