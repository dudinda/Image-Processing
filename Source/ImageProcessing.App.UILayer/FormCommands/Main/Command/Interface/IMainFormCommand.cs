using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.UILayer.FormCommands.Main.UndoRedo;
using ImageProcessing.App.UILayer.FormExposers;
using ImageProcessing.App.UILayer.FormExposers.Main;

namespace ImageProcessing.App.UILayer.FormCommands.Main
{
    internal interface IMainFormCommand : IFormExposer<IMainFormExposer>
    {
        IMainFormContainerCommand Command(ImageContainer command);
        IMainFormUndoRedoCommand Command(UndoRedoAction command);
        void SetCursor(CursorType cursor);
    }
}
