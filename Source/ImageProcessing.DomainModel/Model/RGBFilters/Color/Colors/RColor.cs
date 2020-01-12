using ImageProcessing.Common.Attributes;
using ImageProcessing.Common.Enums;
using ImageProcessing.RGBFilters.Interface;

namespace ImageProcessing.RGBFilters.ColorFilter.Colors
{
    [Color(RGBColors.Red)]
    public class RColor : IColor
    {
        public unsafe void SetPixelColor(byte* ptr)
        {
            ptr[0] = 0;
            ptr[1] = 0;
        }
    }
}
