using System.Windows.Forms;

using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Convolution.Interface;
using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Components;
using ImageProcessing.App.UILayer.FormEventBinders.Convolution.Implementation;
using ImageProcessing.App.UILayer.FormExposers.Convolution;

namespace ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Convolution.Implementation
{
    internal class ConvolutionFormEventBinderWrapper
        : IConvolutionFormEventBinderWrapper
    {
        private readonly ConvolutionFormEventBinder _binder;

        public ConvolutionFormEventBinderWrapper(
            IEventAggregatorWrapper aggregator)
        {
            _binder = new ConvolutionFormEventBinder(aggregator);
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
