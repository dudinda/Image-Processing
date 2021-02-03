using ImageProcessing.App.DomainLayer.DomainFactory;
using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.UILayer.FormModel.Model.UndoRedo;

namespace ImageProcessing.App.UILayer.FormModel.MainFormUndoRedo.Interface
{
    internal interface IMainFormUndoRedoFactory
        : IModelFactory<UndoRedoButton, UndoRedoAction>
    {

    }
}
