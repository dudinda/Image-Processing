using System;
using System.Drawing;

using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.UndoRedo.Interface;
using ImageProcessing.App.ServiceLayer.Services.UndoRedo.Implementation;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.UndoRedo.Implementation
{
    public class UndoRedoServiceWrapper : IUndoRedoServiceWrapper
    {
        private readonly UndoRedoService _service = new UndoRedoService();

        public virtual bool UndoIsEmpty
            => _service.UndoIsEmpty;

        public virtual bool RedoIsEmpty
            => _service.RedoIsEmpty;

        public virtual void AddToRedo(Bitmap bmp)
            => _service.AddToRedo(bmp);

        public virtual void AddToUndo(Bitmap bmp)
            => _service.AddToUndo(bmp);

        public virtual Bitmap Redo()
            => _service.Redo();

        public virtual Bitmap Undo()
            => _service.Undo();
    }
}
