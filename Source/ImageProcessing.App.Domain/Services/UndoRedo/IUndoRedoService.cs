using System.Drawing;

namespace ImageProcessing.App.Domain.Services.UndoRedo
{
    public interface IUndoRedoService<TValue>
    {
        bool UndoIsEmpty { get; }
        bool RedoIsEmpty { get; }
        void AddToUndo(TValue bmp);
        void AddToRedo(TValue bmp);
        public TValue Undo();
        public TValue Redo();
    }
}
