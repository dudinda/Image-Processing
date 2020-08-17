using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.UILayer.FormCommands.Main.UndoRedo.Undo.Interface;
using ImageProcessing.App.UILayer.FormExposers.Main;

namespace ImageProcessing.App.UILayer.FormCommands.Main.UndoRedo.Undo.Implementation
{
    internal class MainFormUndoCommand : IMainFormUndoCommand
    {
        private IMainFormExposer _exposer = null!;

        public void OnElementExpose(IMainFormExposer exposer)
             => _exposer = exposer;

        public void Add(ImageContainer to, Bitmap bmp)
        {
            _exposer.SplitContainerCtr.AddToUndo((bmp, to));
            _exposer.UndoButton.Enabled = !_exposer.SplitContainerCtr.UndoIsEmpty;
        }

        public (Bitmap Bmp, ImageContainer To)? Pop()
        {
            var undo = _exposer.SplitContainerCtr.Undo();

            _exposer.UndoButton.Enabled = !_exposer.SplitContainerCtr.UndoIsEmpty;

            return undo;
        }
    }
}
