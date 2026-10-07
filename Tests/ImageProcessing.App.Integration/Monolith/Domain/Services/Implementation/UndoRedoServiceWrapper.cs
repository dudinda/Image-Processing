using System.Drawing;

using ImageProcessing.App.Domain.Models.Options;
using ImageProcessing.App.Domain.Services.UndoRedo.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.Services.UndoRedo.Interface;

namespace ImageProcessing.App.Integration.Monolith.Domain.Services.UndoRedo.Implementation
{
    public class UndoRedoServiceWrapper : IUndoRedoServiceWrapper
    {
        private readonly UndoRedoService _service;

        public UndoRedoServiceWrapper(UndoRedoOptions options)
        {
            _service = new UndoRedoService(options); 
        }

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
