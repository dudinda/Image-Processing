using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Attributes;
using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.TypeExt;
using ImageProcessing.App.UILayer.Code.Enums;

namespace ImageProcessing.App.UILayer.Form.Main
{
    internal sealed partial class MainForm
    {
        private static readonly Dictionary<string, CommandAttribute>
            _command = typeof(MainForm).GetCommands();

        [Command(
           nameof(ImageContainer.Source) +
           nameof(MainViewAction.ImageIsNull))]
        private bool SourceImageIsNullCommand()
           => Src.Image is null;

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.ImageIsNull))]
        private bool DestinationImageIsNullCommand()
            => Dst.Image is null;

        [Command(
            nameof(ImageContainer.Source) +
            nameof(MainViewAction.Refresh))]
        private void RefreshSourceCommand()
            => Src.Refresh();

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.Refresh))]
        private void RefreshDestinationCommand()
            => Dst.Refresh();

        [Command(
            nameof(ImageContainer.Source) +
            nameof(MainViewAction.GetCopy))]
        private Image GetSourceCopyCommand()
            => SrcImageCopy;

        [Command(
           nameof(ImageContainer.Source) +
           nameof(MainViewAction.SetCopy))]
        private void SetSourceCopyCommand(Image image)
           => SrcImageCopy = image;

        [Command(
           nameof(ImageContainer.Destination) +
           nameof(MainViewAction.SetCopy))]
        private void SetDestinationCopyCommand(Image image)
           => DstImageCopy = image;

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.GetCopy))]
        private Image GetDestinationCopyCommand()
            => DstImageCopy;

        [Command(
            nameof(ImageContainer.Source) +
            nameof(MainViewAction.SetImage))]
        private void SetSourceImageCommand(Image image)
        {
            SrcImage = image;
            Undo.Enabled = true;
        }

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.SetImage))]
        private void SetDestinationImageCommand(Image image)
        {
            DstImage = image;
            Undo.Enabled = true;
        }

        [Command(
            nameof(ImageContainer.Source) +
            nameof(MainViewAction.ResetTrackBar))]
        private void ResetSourceTrackBarValueCommand(int value = 0, bool isEnabled = true)
        {
            SrcZoom.TrackBarValue = value;
            SrcZoom.Enabled = isEnabled;
            SrcZoom.Focus();
        }

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.ResetTrackBar))]
        private void ResetDestinationTrackBarValueCommand(int value = 0, bool isEnabled = true)
        {
            DstZoom.TrackBarValue = value;
            DstZoom.Enabled = isEnabled;
            DstZoom.Focus();
        }

        [Command(
            nameof(ImageContainer.Source) +
            nameof(MainViewAction.Zoom))]
        private Image ZoomSourceImageCommand()
            => SrcZoom.Zoom();

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.Zoom))]
        private Image ZoomDestinationImageCommand()
           => DstZoom.Zoom();

        [Command(nameof(CursorType.Wait))]
        private void SetWaitCursorCommand()
            => Application.UseWaitCursor = true;

        [Command(nameof(CursorType.Default))]
        private void SetDefaultCursorCommand()
            => Application.UseWaitCursor = false;

        [Command(
            nameof(ImageContainer.Source) +
            nameof(MainViewAction.SetToZoom))]
        private Image SetToZoomSourceImageCommand(Image image)
            => SrcZoom.ImageToZoom = image;

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.SetToZoom))]
        private Image SetToZoomDestinationImageCommand(Image image)
           => DstZoom.ImageToZoom = image;

        [Command(nameof(RgbColors.Green))]
        private void SwitchGreenColorCommand()
            => ColorFilterGreen.Checked = !ColorFilterGreen.Checked;

        [Command(nameof(RgbColors.Red))]
        private void SwitchRedColorCommand()
            => ColorFilterRed.Checked = !ColorFilterRed.Checked;

        [Command(nameof(RgbColors.Blue))]
        private void SwitchBlueColorCommand()
            => ColorFilterBlue.Checked = !ColorFilterBlue.Checked;

        [Command(nameof(MainViewAction.GetColor))]
        private RgbColors GetColorCommand()
        {
            var result = default(RgbColors);

            if (ColorFilterRed.Checked)   result |= RgbColors.Red;
            if (ColorFilterBlue.Checked)  result |= RgbColors.Blue;
            if (ColorFilterGreen.Checked) result |= RgbColors.Green;

            return result;
        }
    }
}
