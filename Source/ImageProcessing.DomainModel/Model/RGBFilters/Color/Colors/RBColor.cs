using ImageProcessing.Common.Attributes;
using ImageProcessing.Common.Enums;
using ImageProcessing.RGBFilters.Interface;

namespace ImageProcessing.RGBFilters.ColorFilter.Colors
{
    [Color(RGBColors.Red | RGBColors.Blue)]
    public class RBColor : IColor
    {
        public unsafe void SetPixelColor(byte* ptr)
        {
            ptr[1] = 0;
        }
    }
}
