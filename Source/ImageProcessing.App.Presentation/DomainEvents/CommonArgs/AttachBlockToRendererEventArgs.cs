using ImageProcessing.App.Presentation.Code.Enums;

namespace ImageProcessing.App.Presentation.DomainEvents.CommonArgs
{
    /// <summary>
    /// Attach a sequence of closures to the renderer.
    /// </summary>
    public sealed class AttachBlockToRendererEventArgs : AttachBlockToPaintEventArgs
    {
        public AttachBlockToRendererEventArgs(object block, UndoRedoAction action = UndoRedoAction.Undo) : base(block)
        {
            Action = action;
        }

        public UndoRedoAction Action { get; }
    }
}
