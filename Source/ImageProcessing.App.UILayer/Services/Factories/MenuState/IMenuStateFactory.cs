using ImageProcessing.App.DomainLayer.Factories;
using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.UILayer.Models.MenuState;

namespace ImageProcessing.App.UILayer.Services.Factories.MenuState
{
    internal interface IMenuStateFactory : IModelFactory<IMainMenuState, MenuBtnState>
    {

    }
}
