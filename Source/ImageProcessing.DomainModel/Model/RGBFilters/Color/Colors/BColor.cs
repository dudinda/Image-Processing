using ImageProcessing.RGBFilters.Interface;
using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Attributes;

namespace ImageProcessing.RGBFilters.ColorFilter.Colors
{
    [Color(RGBColors.Blue)]
    public class BColor : IColor
    {
        public unsafe void SetPixelColor(byte* ptr)
        {
            ptr[1] = 0;
            ptr[2] = 0;
        }
    }
}
