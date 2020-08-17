using System;
using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.UILayer.FormCommands.Main.Container.Destination.Interface;
using ImageProcessing.App.UILayer.FormCommands.Main.Container.Source.Interface;
using ImageProcessing.App.UILayer.FormCommands.Main.UndoRedo;
using ImageProcessing.App.UILayer.FormCommands.Main.UndoRedo.Redo.Interface;
using ImageProcessing.App.UILayer.FormCommands.Main.UndoRedo.Undo.Interface;
using ImageProcessing.App.UILayer.FormExposers.Main;

namespace ImageProcessing.App.UILayer.FormCommands.Main.Implementation
{
    internal class MainFormCommand : IMainFormCommand
    {
        private readonly IMainFormDestinationContainerCommand _destination;
        private readonly IMainFormSourceContainerCommand _source;
        private readonly IMainFormRedoCommand _redo;
        private readonly IMainFormUndoCommand _undo;

        public MainFormCommand(
            IMainFormDestinationContainerCommand destination,
            IMainFormSourceContainerCommand source,
            IMainFormUndoCommand undo,
            IMainFormRedoCommand redo)
        {
            _destination = destination;
            _source = source;
            _undo = undo;
            _redo = redo;
        }

        public virtual void OnElementExpose(IMainFormExposer exposer)
        {       
            _undo.OnElementExpose(exposer);
            _redo.OnElementExpose(exposer);
            _source.OnElementExpose(exposer);
            _destination.OnElementExpose(exposer);
        }

        public IMainFormContainerCommand Command(ImageContainer command)
            => command == ImageContainer.Source           ?
                _source      as IMainFormContainerCommand :
                _destination as IMainFormContainerCommand;
        
        public IMainFormUndoRedoCommand Command(UndoRedoAction command)
            => command == UndoRedoAction.Undo     ?
                _undo as IMainFormUndoRedoCommand :
                _redo as IMainFormUndoRedoCommand;

        public void SetCursor(CursorType cursor)
            => Application.UseWaitCursor = cursor == CursorType.Wait;
    }
}
