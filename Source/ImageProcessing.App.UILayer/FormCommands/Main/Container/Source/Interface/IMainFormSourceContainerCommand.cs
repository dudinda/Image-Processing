using ImageProcessing.App.UILayer.FormExposers;
using ImageProcessing.App.UILayer.FormExposers.Main;

namespace ImageProcessing.App.UILayer.FormCommands.Main.Container.Source.Interface
{
    internal interface IMainFormSourceContainerCommand
        : IMainFormContainerCommand, IFormExposer<IMainFormExposer>
    {

    }
}
