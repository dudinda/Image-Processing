using System.Windows.Forms;

using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Convolution.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Convolution.Interface;
using ImageProcessing.App.UILayer.FormExposers.Convolution;

namespace ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Convolution.Implementation
{
    internal class ConvolutionFormEventBinderWrapper
        : IConvolutionFormEventBinderWrapper
    {
        private readonly IConvolutionFormEventBinder _binder;

        public ConvolutionFormEventBinderWrapper(
            IConvolutionFormEventBinder binder)
        {
            _binder = binder;
        }

        public virtual void OnElementExpose(IConvolutionFormExposer form)
        {
            _binder.OnElementExpose(form);
        }


        public virtual bool ProcessCmdKey(IConvolutionFormExposer view, Keys keyData)
        {
            return _binder.ProcessCmdKey(view, keyData);
        }
    }
}
