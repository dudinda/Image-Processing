using ImageProcessing.App.UILayer.FormExposers;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.UILayer.FormCommands
{
    internal interface IFormCommand<in TExposer> : IFormExposer<TExposer>
        where TExposer: class, IView
    {

    }
}
