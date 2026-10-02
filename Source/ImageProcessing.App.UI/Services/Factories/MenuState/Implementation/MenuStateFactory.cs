using System;

using ImageProcessing.App.Presentation.Code.Enums;
using ImageProcessing.App.UI.Models.MenuState;
using ImageProcessing.App.UI.Models.MenuState.Implementation;

namespace ImageProcessing.App.UI.Services.Factories.MenuState.Implementation
{
    class MenuStateFactory : IMenuStateFactory
    {
        public IMainMenuState Get(MenuBtnState state)
            => state
        switch
        {
            MenuBtnState.ImageEmpty
                => new ImageEmptyMenuState(),
            MenuBtnState.ImageLoaded
                => new ImageLoadedMenuState(),

            _    => throw new NotImplementedException(nameof(state))
        };
    }
}
