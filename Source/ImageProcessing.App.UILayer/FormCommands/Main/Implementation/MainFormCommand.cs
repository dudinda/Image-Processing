using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Attributes;
using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.TypeExt;
using ImageProcessing.App.UILayer.Code.Enums;
using ImageProcessing.App.UILayer.FormCommands.Main.Interface;
using ImageProcessing.App.UILayer.FormExposers.Main;

namespace ImageProcessing.App.UILayer.FormCommands.Main.Implementation
{
    internal sealed class MainFormCommand : IMainFormCommand
    {
        private static readonly Dictionary<string, CommandAttribute>
           _command = typeof(MainFormCommand).GetCommands();

        private IMainFormExposer _exposer
            = null!;

        [Command(
           nameof(ImageContainer.Source) +
           nameof(MainViewAction.ImageIsNull))]
        private bool SourceImageIsNullCommand()
           => _exposer.SourceBox.Image is null;

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.ImageIsNull))]
        private bool DestinationImageIsNullCommand()
            => _exposer.DestinationBox.Image is null;

        [Command(
            nameof(ImageContainer.Source) +
            nameof(MainViewAction.Refresh))]
        private void RefreshSourceCommand()
            => _exposer.SourceBox.Refresh();

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.Refresh))]
        private void RefreshDestinationCommand()
            => _exposer.DestinationBox.Refresh();

        [Command(
            nameof(ImageContainer.Source) +
            nameof(MainViewAction.GetCopy))]
        private Image GetSourceCopyCommand()
            => _exposer.SourceImageCopy;

        [Command(
           nameof(ImageContainer.Source) +
           nameof(MainViewAction.SetCopy))]
        private void SetSourceCopyCommand(Image image)
           => _exposer.SourceImageCopy = image;

        [Command(
           nameof(ImageContainer.Destination) +
           nameof(MainViewAction.SetCopy))]
        private void SetDestinationCopyCommand(Image image)
           => _exposer.DestinationImageCopy = image;

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.GetCopy))]
        private Image GetDestinationCopyCommand()
            => _exposer.DestinationImageCopy;

        [Command(
            nameof(ImageContainer.Source) +
            nameof(MainViewAction.SetImage))]
        private void SetSourceImageCommand(Image image)
        {
            _exposer.SourceBox.Image = image;
            _exposer.UndoButton.Enabled = true;
        }

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.SetImage))]
        private void SetDestinationImageCommand(Image image)
        {
            _exposer.DestinationBox.Image = image;
            _exposer.UndoButton.Enabled = true;
        }

        [Command(
            nameof(ImageContainer.Source) +
            nameof(MainViewAction.ResetTrackBar))]
        private void ResetSourceTrackBarValueCommand(int value = 0, bool isEnabled = true)
        {
            _exposer.ZoomSrcTrackBar.TrackBarValue = value;
            _exposer.ZoomSrcTrackBar.Enabled = isEnabled;
            _exposer.ZoomSrcTrackBar.Focus();
        }

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.ResetTrackBar))]
        private void ResetDestinationTrackBarValueCommand(int value = 0, bool isEnabled = true)
        {
            _exposer.ZoomDstTrackBar.TrackBarValue = value;
            _exposer.ZoomDstTrackBar.Enabled = isEnabled;
            _exposer.ZoomDstTrackBar.Focus();
        }

        [Command(
            nameof(ImageContainer.Source) +
            nameof(MainViewAction.Zoom))]
        private Image ZoomSourceImageCommand()
            => _exposer.ZoomSrcTrackBar.Zoom();

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.Zoom))]
        private Image ZoomDestinationImageCommand()
           => _exposer.ZoomDstTrackBar.Zoom();

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
            => _exposer.ZoomSrcTrackBar.ImageToZoom = image;

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.SetToZoom))]
        private Image SetToZoomDestinationImageCommand(Image image)
           => _exposer.ZoomDstTrackBar.ImageToZoom = image;

        public object Function(string command, params object[] args)
            => _command[command].Method.Invoke(this, args);

        public void Procedure(string command, params object[] args)
            => _command[command].Method.Invoke(this, args);

        public void OnElementExpose(IMainFormExposer exposer)
            => _exposer = exposer;
    }
}
