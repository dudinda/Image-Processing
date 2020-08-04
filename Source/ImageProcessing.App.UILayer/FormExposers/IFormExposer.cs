using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.UILayer.FormExposers
{
    internal interface IFormExposer<in TExposer>
        where TExposer : class, IView
    {
        void OnElementExpose(TExposer form);
    }
}
