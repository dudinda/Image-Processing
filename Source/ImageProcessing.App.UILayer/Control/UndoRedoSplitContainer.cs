using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.Utility.DataStructure.FixedStack.Implementation;
using ImageProcessing.Utility.DataStructure.FixedStack.Interface;

namespace ImageProcessing.App.UILayer.Control
{
    public class UndoRedoSplitContainer : SplitContainer
    {
        private readonly IFixedStack<(Bitmap changed, ImageContainer from)> _undo;
        private readonly IFixedStack<(Bitmap returned, ImageContainer to)> _redo;

        public UndoRedoSplitContainer()
        {
            _undo = new FixedStack<(Bitmap changed, ImageContainer from)>(10);
            _redo = new FixedStack<(Bitmap returned, ImageContainer to)>(10);
        }

        public void Add((Bitmap, ImageContainer) action)
            => _undo.Push(action);
        
        public (Bitmap, ImageContainer)? Undo()
        {
            if (!_undo.Any())
            {
                return null;
            }

            _redo.Push(_undo.Pop());

            return _redo.Peek();
        }

        public (Bitmap, ImageContainer)? Redo()
        {
            if (!_redo.Any())
            {
                return null;
            }

            _undo.Push(_redo.Pop());

            return _undo.Peek();
        }
    }
}
