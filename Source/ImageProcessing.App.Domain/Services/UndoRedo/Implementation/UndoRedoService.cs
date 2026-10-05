using System.Drawing;

using ImageProcessing.App.Domain.Code.Collections;
using ImageProcessing.App.Domain.Models.Options;

namespace ImageProcessing.App.Domain.Services.UndoRedo.Implementation
{
    public class UndoRedoService : IUndoRedoService<Bitmap>
    {
        private readonly FixedStackSafe<Bitmap> _undo;
        private readonly FixedStackSafe<Bitmap> _redo;

        public UndoRedoService(UndoRedoOptions options)
        {
            _undo = new FixedStackSafe<Bitmap>(options.MaxUndoCount);
            _redo = new FixedStackSafe<Bitmap>(options.MaxRedoCount);
        }

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
