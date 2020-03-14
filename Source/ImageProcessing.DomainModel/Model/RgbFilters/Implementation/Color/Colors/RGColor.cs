using ImageProcessing.Common.Attributes;
using ImageProcessing.Common.Enums;
using ImageProcessing.DomainModel.Model.RgbFilters.Interface.Color;

namespace ImageProcessing.DomainModel.Model.RgbFilters.Implementation.Color.Colors
{
    [Color(RGBColors.Red | RGBColors.Green)]
    internal sealed class RGColor : IColor
    {
        public unsafe void SetPixelColor(byte* ptr)
        {
            ptr[0] = 0;
        }
    }
}
