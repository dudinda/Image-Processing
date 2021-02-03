using ImageProcessing.App.DomainLayer.DomainFactory;
using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.UILayer.FormModel.Model.Container;

namespace ImageProcessing.App.UILayer.FormCommands.Main
{
    internal interface IMainFormContainerFactory
        : IModelFactory<MainFormContainer, ImageContainer>
    {

    }
}
