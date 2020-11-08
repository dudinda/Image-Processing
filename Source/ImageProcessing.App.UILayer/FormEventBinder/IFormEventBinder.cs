using ImageProcessing.App.UILayer.FormExposers;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.UILayer.FormEventBinders
{
    internal interface IFormEventBinder<in TExposer> : IFormExposer<TExposer>
        where TExposer : class
    {

    }
}
