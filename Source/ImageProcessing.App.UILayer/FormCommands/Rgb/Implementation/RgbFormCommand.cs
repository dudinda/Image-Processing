using System.Collections.Generic;

using ImageProcessing.App.CommonLayer.Attributes;
using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.TypeExt;
using ImageProcessing.App.UILayer.Code.Enums;
using ImageProcessing.App.UILayer.Exposers.Rgb;
using ImageProcessing.App.UILayer.FormCommands.Rgb.Interface;

using static ImageProcessing.App.CommonLayer.Enums.RgbColors;

namespace ImageProcessing.App.UILayer.FormCommands.Rgb.Implementation
{
    internal class RgbFormCommand : IRgbFormCommand
    {
        private static readonly Dictionary<string, CommandAttribute>
          _command = typeof(RgbFormCommand).GetCommands();

        private IRgbFormExposer _exposer
            = null!;

        [Command(nameof(RgbColors.Green))]
        private void SwitchGreenColorCommand()
            => _exposer.GreenButton.Checked = !_exposer.GreenButton.Checked;

        [Command(nameof(RgbColors.Red))]
        private void SwitchRedColorCommand()
            => _exposer.RedButton.Checked   = !_exposer.RedButton.Checked;

        [Command(nameof(RgbColors.Blue))]
        private void SwitchBlueColorCommand()
            => _exposer.BlueButton.Checked  = !_exposer.BlueButton.Checked;

        [Command(nameof(RgbViewAction.GetColor))]
        private RgbColors GetColorCommand()
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

        public object Function(string command, params object[] args)
            => _command[command].Method.Invoke(this, args);
        
        public void Procedure(string command, params object[] args)
            => _command[command].Method.Invoke(this, args);

        public void OnElementExpose(IRgbFormExposer exposer)
            => _exposer = exposer;
    }
}
