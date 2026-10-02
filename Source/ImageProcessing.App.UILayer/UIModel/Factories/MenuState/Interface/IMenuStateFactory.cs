using ImageProcessing.App.DomainLayer.Factories;
using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.UILayer.UIModel.Models.MainMenuState.Interface;

namespace ImageProcessing.App.UILayer.UIModel.Factories.MenuState.Interface
{
    internal interface IMenuStateFactory : IModelFactory<IMainMenuState, MenuBtnState>
    {

    }
}
