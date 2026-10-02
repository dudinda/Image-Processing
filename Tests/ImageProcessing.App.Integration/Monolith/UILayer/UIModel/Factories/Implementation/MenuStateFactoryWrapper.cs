using System;

using ImageProcessing.App.Integration.Monolith.UILayer.UIModel.Factories.Interface;
using ImageProcessing.App.Presentation.Code.Enums;
using ImageProcessing.App.UILayer.Models.MenuState;
using ImageProcessing.App.UILayer.Services.Factories.MenuState.Implementation;

namespace ImageProcessing.App.Integration.Monolith.UILayer.UIModel.Factories.Implementation
{
    public class MenuStateFactoryWrapper : IMenuStateFactoryWrapper
    {
        private readonly MenuStateFactory _factory = new MenuStateFactory();

        public virtual IMainMenuState Get(MenuBtnState model)
            => _factory.Get(model);
    }
}
