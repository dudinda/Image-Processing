using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.UILayer.FormExposers
{
    internal interface IFormExposer<in TExposer>
        where TExposer : class
    {
        void OnElementExpose(TExposer form);
    }

    internal interface IFormExposer<in TExposer, out TModel>
        where TExposer : class
    {
        TModel OnElementExpose(TExposer form);
    }
}
