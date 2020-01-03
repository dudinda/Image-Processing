using ImageProcessing.Attributes;
using ImageProcessing.Enum;
using ImageProcessing.RGBFilters.Abstract;

using System;

namespace ImageProcessing.RGBFilters.ColorFilter.Colors
{
    [Color(RGBColors.Red | RGBColors.Blue)]
    public class RBColor : IColor
    {
        public unsafe void SetPixelColor(byte* ptr)
        {
            ptr[0] = 255;
            ptr[1] = 0;
            ptr[2] = 255;
        }
    }
}
