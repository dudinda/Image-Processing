using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Attributes;
using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.TypeExt;
using ImageProcessing.App.CommonLayer.Helpers;
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
        private bool SourceImageIsNull()
           => Src.Image is null;

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.ImageIsNull))]
        private bool DestinationImageIsNull()
            => Dst.Image is null;

        [Command(
            nameof(ImageContainer.Source) +
            nameof(MainViewAction.Refresh))]
        private void RefreshSource()
            => Src.Refresh();

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.Refresh))]
        private void RefreshDestination()
            => Dst.Refresh();

        [Command(
            nameof(ImageContainer.Source) +
            nameof(MainViewAction.GetCopy))]
        private Image GetSourceCopy()
            => SrcImageCopy;

        [Command(
           nameof(ImageContainer.Source) +
           nameof(MainViewAction.SetCopy))]
        private void SetSourceCopy(Image image)
           => SrcImageCopy = Requires.IsNotNull(
               image, nameof(image));

        [Command(
           nameof(ImageContainer.Destination) +
           nameof(MainViewAction.SetCopy))]
        private void SetDestinationCopy(Image image)
           => DstImageCopy = Requires.IsNotNull(
               image, nameof(image));

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.GetCopy))]
        private Image GetDestinationCopy()
            => DstImageCopy;

        [Command(
            nameof(ImageContainer.Source) +
            nameof(MainViewAction.SetImage))]
        private void SetSourceImage(Image image)
        {
            SrcImage = Requires.IsNotNull(
                image, nameof(image));
            Undo.Enabled = true;
        }

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.SetImage))]
        private void SetDestinationImage(Image image)
        {
            DstImage = Requires.IsNotNull(
                image, nameof(image));
            Undo.Enabled = true;
        }

        [Command(
            nameof(ImageContainer.Source) +
            nameof(MainViewAction.ResetTrackBar))]
        private void ResetSourceTrackBarValue(int value = 0, bool isEnabled = true)
        {
            SrcZoom.TrackBarValue = value;
            SrcZoom.Enabled = isEnabled;
            SrcZoom.Focus();
        }

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.ResetTrackBar))]
        private void ResetDestinationTrackBarValue(int value = 0, bool isEnabled = true)
        {
            DstZoom.TrackBarValue = value;
            DstZoom.Enabled = isEnabled;
            DstZoom.Focus();
        }

        [Command(
            nameof(ImageContainer.Source) +
            nameof(MainViewAction.Zoom))]
        private Image ZoomSourceImage()
            => SrcZoom.Zoom();

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.Zoom))]
        private Image ZoomDestinationImage()
           => DstZoom.Zoom();

        [Command(nameof(CursorType.Wait))]
        private void SetWaitCursor()
            => Application.UseWaitCursor = true;

        [Command(nameof(CursorType.Default))]
        private void SetDefaultCursor()
            => Application.UseWaitCursor = false;

        [Command(
            nameof(ImageContainer.Source) +
            nameof(MainViewAction.SetToZoom))]
        private Image SetToZoomSourceImage(Image image)
            => SrcZoom.ImageToZoom = Requires.IsNotNull(
                image, nameof(image));

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.SetToZoom))]
        private Image SetToZoomDestinationImage(Image image)
           => DstZoom.ImageToZoom = Requires.IsNotNull(
               image, nameof(image));

        [Command(nameof(RgbColors.Green))]
        private void SwitchGreenColor()
            => ColorFilterGreen.Checked = !ColorFilterGreen.Checked;

        [Command(nameof(RgbColors.Red))]
        private void SwitchRedColor()
            => ColorFilterRed.Checked = !ColorFilterRed.Checked;

        [Command(nameof(RgbColors.Blue))]
        private void SwitchBlueColor()
            => ColorFilterBlue.Checked = !ColorFilterBlue.Checked;

        [Command(nameof(MainViewAction.GetColor))]
        private RgbColors GetColor()
        {
            var result = default(RgbColors);

            if (ColorFilterRed.Checked)   result |= RgbColors.Red;
            if (ColorFilterBlue.Checked)  result |= RgbColors.Blue;
            if (ColorFilterGreen.Checked) result |= RgbColors.Green;

            return result;
        }

    }
}
