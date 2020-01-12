using ImageProcessing.Common.Attributes;
using ImageProcessing.Common.Enums;
using ImageProcessing.RGBFilters.Interface;

namespace ImageProcessing.RGBFilters.ColorFilter.Colors
{
    [Color(RGBColors.Green)]
    public class GColor : IColor
    {
        public unsafe void SetPixelColor(byte* ptr)
        {
            ptr[0] = 0;
            ptr[2] = 0;
        }
    }
}
