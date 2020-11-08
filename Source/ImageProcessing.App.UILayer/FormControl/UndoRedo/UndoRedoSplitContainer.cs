using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.Utility.DataStructure.FixedStackSrc.Implementation.Safe;
using ImageProcessing.Utility.DataStructure.FixedStackSrc.Interface;

namespace ImageProcessing.App.UILayer.Control
{
    public class UndoRedoSplitContainer : SplitContainer
    {
        private readonly IFixedStack<(Bitmap changed, ImageContainer from)> _undo;
        private readonly IFixedStack<(Bitmap returned, ImageContainer to)> _redo;

        public UndoRedoSplitContainer()
        {
            _undo = new FixedStackSafe<(Bitmap changed, ImageContainer from)>(10);
            _redo = new FixedStackSafe<(Bitmap returned, ImageContainer to)>(10);
        }


        public bool UndoIsEmpty
            => _undo.IsEmpty;

        public bool RedoIsEmpty
            => _redo.IsEmpty;

        public void AddToUndo((Bitmap Bmp, ImageContainer To) action)
            => _undo.Push(action);

        public void AddToRedo((Bitmap Bmp, ImageContainer To) action)
           => _redo.Push(action);

        public (Bitmap Bmp, ImageContainer To) Undo()
            => _undo.Pop();

        public (Bitmap Bmp, ImageContainer To) Redo()
            => _redo.Pop();
    }
}
