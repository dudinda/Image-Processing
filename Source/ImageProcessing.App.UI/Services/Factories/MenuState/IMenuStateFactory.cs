using ImageProcessing.App.Domain.Factories;
using ImageProcessing.App.Presentation.Code.Enums;
using ImageProcessing.App.UI.Models.MenuState;

namespace ImageProcessing.App.UI.Services.Factories.MenuState
{
    internal interface IMenuStateFactory : IModelFactory<IMainMenuState, MenuBtnState>
    {

    }
}
