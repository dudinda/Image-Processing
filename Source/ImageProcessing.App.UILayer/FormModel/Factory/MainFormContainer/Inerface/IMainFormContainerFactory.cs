using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.UILayer.FormModel.Model.Container;
using ImageProcessing.Microkernel.MVP.Model;

namespace ImageProcessing.App.UILayer.FormCommands.Main
{
    internal interface IMainFormContainerFactory
        : IModelFactory<MainFormContainer, ImageContainer>
    {

    }
}
