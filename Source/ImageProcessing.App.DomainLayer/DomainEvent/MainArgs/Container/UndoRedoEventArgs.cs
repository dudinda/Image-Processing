using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.DomainLayer.DomainEvent.MainArgs.Container
{
    public sealed class UndoRedoEventArgs : BaseEventArgs
    {
        public UndoRedoEventArgs(UndoRedoAction action) : base()
            => Action = action;

        public UndoRedoAction Action { get; }
    }
}
