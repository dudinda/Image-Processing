using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.UILayer.Exposers.Rgb;
using ImageProcessing.App.UILayer.FormExposers;

namespace ImageProcessing.App.UILayer.FormCommands.Rgb.Interface
{
    internal interface IRgbFormColor : IFormExposer<IRgbFormExposer>
    {
        RgbColors GetSelectedColors(RgbColors color);
    }
}
