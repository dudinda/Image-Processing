using ImageProcessing.Common.Attributes;
using ImageProcessing.Common.Enums;
using ImageProcessing.DomainModel.Model.RgbFilters.Interface.Color;

namespace ImageProcessing.DomainModel.Model.RgbFilters.Implementation.Color.Colors
{
    [Color(RGBColors.Blue)]
    internal sealed class BColor : IColor
    {
        public unsafe void SetPixelColor(byte* ptr)
        {
            ptr[1] = 0;
            ptr[2] = 0;
        }
    }
}
