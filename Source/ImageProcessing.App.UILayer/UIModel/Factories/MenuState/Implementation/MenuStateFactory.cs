using System;

using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.UILayer.UIModel.Factories.MenuState.Interface;
using ImageProcessing.App.UILayer.UIModel.Models.MainMenuState.Interface;
using ImageProcessing.App.UILayer.UIModel.Models.MenuState.Implementation;

namespace ImageProcessing.App.UILayer.UIModel.Factories.MenuState.Implementation
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
