using ImageProcessing.App.Integration.Monolith.UILayer.UIModel.Factories.MainFormContainer.Interface;
using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.UILayer.FormCommands.Main;

namespace ImageProcessing.App.Integration.Monolith.UILayer.UIModel.Factories.MainFormContainer.Implementation
{
    internal class MainFormContainerFactoryWrapper : IMainFormContainerFactoryWrapper
    {
        private readonly IMainFormContainerFactory _factory;

        public MainFormContainerFactoryWrapper(
            IMainFormContainerFactory factory)
        {
            _factory = factory;
        }


        public virtual App.UILayer.FormModel.Model.Container.MainFormContainer Get(ImageContainer model)
        {
            return _factory.Get(model);
        }
    }
}
