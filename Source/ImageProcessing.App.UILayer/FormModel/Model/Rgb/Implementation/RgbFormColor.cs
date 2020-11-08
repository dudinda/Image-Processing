using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.UILayer.Exposers.Rgb;
using ImageProcessing.App.UILayer.FormCommands.Rgb.Interface;

using static ImageProcessing.App.CommonLayer.Enums.RgbColors;

namespace ImageProcessing.App.UILayer.FormCommands.Rgb.Implementation
{
    internal class RgbFormColor : IRgbFormColor
    {
        private IRgbFormExposer _exposer = null!;

        public RgbColors GetSelectedColors(RgbColors color)
        {
            var result = Unknown;

            if (_exposer.RedButton.Checked)
            {
                result |= Red;
            }
                
            if (_exposer.BlueButton.Checked)
            {
                result |= Blue;
            }
                
            if (_exposer.GreenButton.Checked)
            {
                result |= Green;
            }

            if(result == Unknown)
            {
                result |= Green | Blue | Red;
            }
               
            return result;
        }

        public void OnElementExpose(IRgbFormExposer exposer)
            => _exposer = exposer;
    }
}
