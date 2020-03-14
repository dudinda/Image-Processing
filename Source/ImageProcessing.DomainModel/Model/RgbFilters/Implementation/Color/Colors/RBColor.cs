using ImageProcessing.Common.Attributes;
using ImageProcessing.Common.Enums;
using ImageProcessing.DomainModel.Model.RgbFilters.Interface.Color;

namespace ImageProcessing.DomainModel.Model.RgbFilters.Implementation.Color.Colors
{
    [Color(RGBColors.Red | RGBColors.Blue)]
    internal sealed class RBColor : IColor
    {
        public unsafe void SetPixelColor(byte* ptr)
        {
            ptr[1] = 0;
        }
    }
}
