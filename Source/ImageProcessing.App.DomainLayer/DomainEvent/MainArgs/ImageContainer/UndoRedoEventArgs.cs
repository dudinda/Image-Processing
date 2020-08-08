using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.Base;

namespace ImageProcessing.App.DomainLayer.DomainEvent.MainArgs.ImageContainer
{
    public sealed class UndoRedoEventArgs : BaseEventArgs
    {
        public UndoRedoEventArgs(UndoRedoAction action) : base()
            => Action = action;

        public UndoRedoAction Action { get; }
    }
}
