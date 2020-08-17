
using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.UILayer.FormCommands.Main.UndoRedo.Redo.Interface;
using ImageProcessing.App.UILayer.FormExposers.Main;

namespace ImageProcessing.App.UILayer.FormCommands.Main.UndoRedo.Redo.Implementation
{
    internal class MainFormRedoCommand : IMainFormRedoCommand
    {
        private IMainFormExposer _exposer = null!;

        public void OnElementExpose(IMainFormExposer exposer)
             => _exposer = exposer;

        public void Add(ImageContainer to, Bitmap bmp)
        {
            _exposer.SplitContainerCtr.AddToRedo((bmp, to));
            _exposer.RedoButton.Enabled = !_exposer.SplitContainerCtr.RedoIsEmpty;
        }
       
        public (Bitmap Bmp, ImageContainer To)? Pop()
        {
            var redo = _exposer.SplitContainerCtr.Redo();

            _exposer.RedoButton.Enabled = !_exposer.SplitContainerCtr.RedoIsEmpty;

            return redo;
        }             
    }
}
