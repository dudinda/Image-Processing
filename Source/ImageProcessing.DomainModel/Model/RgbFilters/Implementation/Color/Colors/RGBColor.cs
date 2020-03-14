using ImageProcessing.Common.Attributes;
using ImageProcessing.Common.Enums;
using ImageProcessing.DomainModel.Model.RgbFilters.Interface.Color;

namespace ImageProcessing.DomainModel.Model.RgbFilters.Implementation.Color.Colors
{
    [Color(RGBColors.Red | RGBColors.Blue | RGBColors.Green)]
    internal sealed class RGBColor : IColor
    {
        public unsafe void SetPixelColor(byte* ptr)
        {

        }
    }
}
