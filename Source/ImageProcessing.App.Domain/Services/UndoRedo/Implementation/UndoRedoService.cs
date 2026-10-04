using System.Drawing;

using ImageProcessing.Utility.DataStructure.FixedStackSrc.Implementation.Safe;

namespace ImageProcessing.App.Domain.Services.UndoRedo.Implementation
{
    public class UndoRedoService : IUndoRedoService<Bitmap>
    {
        private readonly FixedStackSafe<Bitmap> _undo = new FixedStackSafe<Bitmap>(10);
        private readonly FixedStackSafe<Bitmap> _redo = new FixedStackSafe<Bitmap>(10);

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
