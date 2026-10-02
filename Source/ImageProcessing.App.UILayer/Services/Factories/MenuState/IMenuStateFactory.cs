using ImageProcessing.App.Domain.Factories;
using ImageProcessing.App.Presentation.Code.Enums;
using ImageProcessing.App.UILayer.Models.MenuState;

namespace ImageProcessing.App.UILayer.Services.Factories.MenuState
{
    internal interface IMenuStateFactory : IModelFactory<IMainMenuState, MenuBtnState>
    {

    }
}
