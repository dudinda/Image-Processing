using System.Collections.Generic;

using ImageProcessing.App.CommonLayer.Attributes;
using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.TypeExt;
using ImageProcessing.App.PresentationLayer.Views.Rgb;
using ImageProcessing.App.UILayer.Code.Enums;
using ImageProcessing.App.UILayer.ElementCommands.Rgb.Interface;
using ImageProcessing.App.UILayer.FormControls.Rgb;

namespace ImageProcessing.App.UILayer.ElementCommands.Rgb.Implementation
{
    internal sealed class RgbElementCommand : IRgbElementCommand
    {
        private static readonly Dictionary<string, CommandAttribute>
          _command = typeof(RgbElementCommand).GetCommands();

        private IRgbElementExposer _exposer;

        [Command(nameof(RgbColors.Green))]
        private void SwitchGreenColorCommand()
            => _exposer.GreenButton.Checked = !_exposer.GreenButton.Checked;

        [Command(nameof(RgbColors.Red))]
        private void SwitchRedColorCommand()
            => _exposer.RedButton.Checked = !_exposer.RedButton.Checked;

        [Command(nameof(RgbColors.Blue))]
        private void SwitchBlueColorCommand()
            => _exposer.BlueButton.Checked = !_exposer.BlueButton.Checked;

        [Command(nameof(RgbViewAction.GetColor))]
        private RgbColors GetColorCommand()
        {
            var result = default(RgbColors);

            if (_exposer.RedButton.Checked)
                result |= RgbColors.Red;
            if (_exposer.BlueButton.Checked)
                result |= RgbColors.Blue;
            if (_exposer.GreenButton.Checked)
                result |= RgbColors.Green;

            return result;
        }

        public object Function(string command, params object[] args)
            => _command[command].Method.Invoke(this, args);
        
        public void Procedure(string command, params object[] args)
            => _command[command].Method.Invoke(this, args);

        public void Expose(IRgbElementExposer exposer)
            => _exposer = exposer;
    }
}
