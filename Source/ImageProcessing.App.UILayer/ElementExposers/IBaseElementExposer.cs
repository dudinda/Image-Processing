using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.UILayer.ElementExposers
{
    internal interface IElementExposer<in TExposer>
        where TExposer : class, IView
    {
        void Expose(TExposer form);
    }
}
