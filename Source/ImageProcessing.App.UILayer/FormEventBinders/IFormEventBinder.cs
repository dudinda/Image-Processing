using ImageProcessing.App.UILayer.FormExposers;

namespace ImageProcessing.App.UILayer.FormEventBinders
{
    internal interface IFormEventBinder<in TExposer> : IFormExposer<TExposer>
        where TExposer : class
    {

    }
}
