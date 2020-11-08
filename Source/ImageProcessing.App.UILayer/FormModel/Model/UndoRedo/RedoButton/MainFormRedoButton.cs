using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.UILayer.FormModel.Model.UndoRedo;

namespace ImageProcessing.App.UILayer.FormModel.Model.RedoButton.Implementation
{
    internal sealed class MainFormRedoButton : UndoRedoButton
    {
        public override void Add(ImageContainer to, Bitmap bmp)
        {
            Exposer.SplitContainerCtr.AddToRedo((bmp, to));
            Exposer.RedoButton.Enabled = !Exposer.SplitContainerCtr.RedoIsEmpty;
        }
       
        public override (Bitmap Bmp, ImageContainer To) Pop()
        {
            var redo = Exposer.SplitContainerCtr.Redo();

            Exposer.RedoButton.Enabled = !Exposer.SplitContainerCtr.RedoIsEmpty;

            return redo;
        }             
    }
}
