using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.UILayer.Exposers.Rgb;

namespace ImageProcessing.App.UILayer.FormCommands.Rgb.Interface
{
    internal interface IRgbFormCommand : IFormCommand<IRgbFormExposer>
    {
        RgbColors GetSelectedColors(RgbColors color);
    }
}
