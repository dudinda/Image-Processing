using System;

using ImageProcessing.App.Integration.Monolith.UILayer.UIModel.Factories.Interface;
using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.UILayer.UIModel.Factories.MenuState.Implementation;
using ImageProcessing.App.UILayer.UIModel.Models.MainMenuState.Interface;

namespace ImageProcessing.App.Integration.Monolith.UILayer.UIModel.Factories.Implementation
{
    public class MenuStateFactoryWrapper : IMenuStateFactoryWrapper
    {
        private readonly MenuStateFactory _factory = new MenuStateFactory();

        public virtual IMainMenuState Get(MenuBtnState model)
            => _factory.Get(model);
    }
}
