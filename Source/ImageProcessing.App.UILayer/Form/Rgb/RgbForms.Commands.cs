using System.Collections.Generic;

using ImageProcessing.App.CommonLayer.Attributes;
using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.TypeExt;
using ImageProcessing.App.UILayer.Code.Enums;

namespace ImageProcessing.App.UILayer.Form.Rgb
{
    partial class RgbForm
    {
        private static readonly Dictionary<string, CommandAttribute>
           _command = typeof(RgbForm).GetCommands();

        [Command(nameof(RgbColors.Green))]
        private void SwitchGreenColorCommand()
            => GreenColor.Checked = !GreenColor.Checked;

        [Command(nameof(RgbColors.Red))]
        private void SwitchRedColorCommand()
            => RedColor.Checked = !RedColor.Checked;

        [Command(nameof(RgbColors.Blue))]
        private void SwitchBlueColorCommand()
            => BlueColor.Checked = !BlueColor.Checked;

        [Command(nameof(RgbViewAction.GetColor))]
        private RgbColors GetColorCommand()
        {
            var result = default(RgbColors);

            if (RedColor.Checked)
                result |= RgbColors.Red;
            if (BlueColor.Checked)
                result |= RgbColors.Blue;
            if (GreenColor.Checked)
                result |= RgbColors.Green;

            return result;
        }
    }
}
