using ImageProcessing.App.UILayer.ElementExposers;
using ImageProcessing.App.UILayer.FormElements.Main;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.UILayer.FormControls.Base
{
    internal interface IElementEventBinder<in TExposer> : IElementExposer<TExposer>
        where TExposer : class, IView
    {

    }
}
