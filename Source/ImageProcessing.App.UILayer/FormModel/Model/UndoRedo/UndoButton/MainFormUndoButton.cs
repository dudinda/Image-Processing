using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.UILayer.FormModel.Model.UndoRedo;

namespace ImageProcessing.App.UILayer.FormModel.Model.UndoButton.Implementation
{
    internal sealed class MainFormUndoButton : UndoRedoButton
    {
        public override void Add(ImageContainer to, Bitmap bmp)
        {
            Exposer.SplitContainerCtr.AddToUndo((bmp, to));
            Exposer.UndoButton.Enabled = !Exposer.SplitContainerCtr.UndoIsEmpty;
        }

        public override (Bitmap Bmp, ImageContainer To) Pop()
        {
            var undo = Exposer.SplitContainerCtr.Undo();

            Exposer.UndoButton.Enabled = !Exposer.SplitContainerCtr.UndoIsEmpty;

            return undo;
        }
    }
}
