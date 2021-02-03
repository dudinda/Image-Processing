using System;

using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.UILayer.FormCommands.Main;
using ImageProcessing.App.UILayer.FormCommands.Main.Container.Destination.Implementation;
using ImageProcessing.App.UILayer.FormCommands.Main.Container.Source.Implementation;
using ImageProcessing.App.UILayer.FormModel.Model.Container;

namespace ImageProcessing.App.UILayer.FormModel.Factory.MainContainer.Implementation
{
    internal class MainFormContainerFactory : IMainFormContainerFactory
    {
        public MainFormContainer Get(ImageContainer container)
            => container
        switch
        {
            ImageContainer.Source
                => new MainFormSourceContainer(),
            ImageContainer.Destination
                => new MainFormDestinationContainer(),

            _   => throw new NotSupportedException(nameof(container))
        };      
    }
}
