using ImageProcessing.Common.Attributes;
using ImageProcessing.Common.Enums;
using ImageProcessing.RGBFilters.Interface;

namespace ImageProcessing.RGBFilters.ColorFilter.Colors
{
    [Color(RGBColors.Red | RGBColors.Blue | RGBColors.Green)]
    public class RGBColor : IColor
    {
        public unsafe void SetPixelColor(byte* ptr)
        {

        }
    }
}
