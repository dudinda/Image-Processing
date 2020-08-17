
using ImageProcessing.App.UILayer.FormExposers.Main;

namespace ImageProcessing.App.UILayer.FormCommands.Main.UndoRedo.Undo.Interface
{
    interface IMainFormUndoCommand
        : IMainFormUndoRedoCommand, IFormCommand<IMainFormExposer>
    {
    }
}
