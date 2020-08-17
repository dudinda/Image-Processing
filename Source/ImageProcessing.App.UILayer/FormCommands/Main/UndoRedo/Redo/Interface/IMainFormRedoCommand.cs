using ImageProcessing.App.UILayer.FormExposers.Main;

namespace ImageProcessing.App.UILayer.FormCommands.Main.UndoRedo.Redo.Interface
{
    internal interface IMainFormRedoCommand
         : IMainFormUndoRedoCommand, IFormCommand<IMainFormExposer>
    {
        
    }
}
