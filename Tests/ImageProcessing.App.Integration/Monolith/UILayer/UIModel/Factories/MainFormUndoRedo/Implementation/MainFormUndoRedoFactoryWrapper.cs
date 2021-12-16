using ImageProcessing.App.Integration.Monolith.UILayer.UIModel.Factories.MainFormUndoRedo.Interface;
using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.UILayer.FormModel.MainFormUndoRedo.Interface;
using ImageProcessing.App.UILayer.FormModel.Model.UndoRedo;

namespace ImageProcessing.App.Integration.Monolith.UILayer.UIModel.Factories.MainFormUndoRedo.Implementation
{
    internal class MainFormUndoRedoFactoryWrapper : IMainFormUndoRedoFactoryWrapper
    {
        private readonly IMainFormUndoRedoFactory _factory;

        public MainFormUndoRedoFactoryWrapper(
            IMainFormUndoRedoFactory factory)
        {
            _factory = factory;
        }

        public virtual UndoRedoButton Get(UndoRedoAction model)
        {
            return _factory.Get(model);
        }
    }
}
