using System.Drawing;

using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Services.UndoRedo.Interface;
using ImageProcessing.Utility.DataStructure.FixedStackSrc.Implementation.Safe;
using ImageProcessing.Utility.DataStructure.FixedStackSrc.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.UndoRedo.Implementation
{
    public class UndoRedoService : IUndoRedoService<Bitmap>
    {
        private readonly IFixedStack<Bitmap> _undo = new FixedStackSafe<Bitmap>(10);
        private readonly IFixedStack<Bitmap> _redo = new FixedStackSafe<Bitmap>(10);

        public bool UndoIsEmpty
         => _undo.IsEmpty;

        public bool RedoIsEmpty
            => _redo.IsEmpty;

        public void AddToUndo(Bitmap bmp)
            => _undo.Push(bmp);

        public void AddToRedo(Bitmap bmp)
           => _redo.Push(bmp);

        public Bitmap Undo()
            => _undo.Pop();

        public Bitmap Redo()
            => _redo.Pop();
    }
}
