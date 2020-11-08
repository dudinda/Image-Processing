using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.UILayer.FormModel.Model.UndoRedo;
using ImageProcessing.Microkernel.MVP.Model;

namespace ImageProcessing.App.UILayer.FormModel.MainFormUndoRedo.Interface
{
    internal interface IMainFormUndoRedoFactory
        : IModelFactory<UndoRedoButton, UndoRedoAction>
    {

    }
}
