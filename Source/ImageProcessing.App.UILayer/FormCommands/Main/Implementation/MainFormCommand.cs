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
    internal class MainFormCommand : IMainFormCommand
    {
        private static readonly Dictionary<string, CommandAttribute>
           _command = typeof(MainFormCommand).GetCommands();

        private IMainFormExposer _exposer
            = null!;

        [Command(
           nameof(ImageContainer.Source) +
           nameof(MainViewAction.ImageIsNull))]
        private bool SourceImageIsDefaultCommand()
           => _exposer.SrcImageCopy == _exposer.DefaultImage;

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.ImageIsNull))]
        private bool DestinationImageIsDefaultCommand()
            => _exposer.DstImageCopy == _exposer.DefaultImage;

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
        private Image? GetSourceCopyCommand()
            => _exposer.SrcImageCopy;

        [Command(
           nameof(ImageContainer.Source) +
           nameof(MainViewAction.SetCopy))]
        private void SetSourceCopyCommand(Image image)
           => _exposer.SrcImageCopy = image;

        [Command(
           nameof(ImageContainer.Destination) +
           nameof(MainViewAction.SetCopy))]
        private void SetDestinationCopyCommand(Image image)
           => _exposer.DstImageCopy = image;

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.GetCopy))]
        private Image? GetDestinationCopyCommand()
            => _exposer.DstImageCopy;

        [Command(
            nameof(ImageContainer.Source) +
            nameof(MainViewAction.SetImage))]
        private void SetSourceImageCommand(Image image)
        {
            _exposer.SourceImage = image;
        }

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.SetImage))]
        private void SetDestinationImageCommand(Image image)
        {
            _exposer.DestinationImage = image;
        }

        [Command(
            nameof(ImageContainer.Source) +
            nameof(MainViewAction.ResetTrackBar))]
        private void ResetSourceTrackBarValueCommand(int value = 0)
        {
            _exposer.ZoomSrcTrackBar.TrackBarValue = value;
            _exposer.ZoomSrcTrackBar.Enabled = _exposer.SourceImage != null;
            _exposer.ZoomSrcTrackBar.Focus();
        }

        [Command(
            nameof(ImageContainer.Destination) +
            nameof(MainViewAction.ResetTrackBar))]
        private void ResetDestinationTrackBarValueCommand(int value = 0)
        {
            _exposer.ZoomDstTrackBar.TrackBarValue = value;
            _exposer.ZoomDstTrackBar.Enabled = _exposer.DestinationImage != null;
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


        [Command(
            nameof(UndoRedoAction.Undo) +
            nameof(MainViewAction.AddToUndoRedo))]
        private void AddToUndoCommand(ImageContainer to, Bitmap bmp)
        {
            _exposer.SplitContainerCtr.AddToUndo((bmp, to));       
            _exposer.UndoButton.Enabled = !_exposer.SplitContainerCtr.UndoIsEmpty;
        }

        [Command(
          nameof(UndoRedoAction.Redo) +
          nameof(MainViewAction.AddToUndoRedo))]
        private void AddToRedoCommand(ImageContainer to, Bitmap bmp)
        {
            _exposer.SplitContainerCtr.AddToRedo((bmp, to));
            _exposer.RedoButton.Enabled = !_exposer.SplitContainerCtr.RedoIsEmpty;
        }

        [Command(nameof(UndoRedoAction.Undo))]
        private (Bitmap Bmp, ImageContainer To)? UndoCommand()
        {
            var undo = _exposer.SplitContainerCtr.Undo();

            _exposer.UndoButton.Enabled = !_exposer.SplitContainerCtr.UndoIsEmpty;

            return undo;
        }
      
        [Command(nameof(UndoRedoAction.Redo))]
        private (Bitmap Bmp, ImageContainer To)? RedoCommand()
        {
            var redo = _exposer.SplitContainerCtr.Redo();

            _exposer.RedoButton.Enabled = !_exposer.SplitContainerCtr.RedoIsEmpty;

            return redo;
        }

        public virtual object Function(string command, params object[] args)
            => _command[command].Method.Invoke(this, args);

        public virtual void Procedure(string command, params object[] args)
            => _command[command].Method.Invoke(this, args);

        public virtual void OnElementExpose(IMainFormExposer exposer)
            => _exposer = exposer;
    }
}
