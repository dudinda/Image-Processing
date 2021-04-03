using System;
using System.Windows.Forms;

using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Convolution.Interface;
using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Components;
using ImageProcessing.App.UILayer.FormExposers.Convolution;

namespace ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Convolution.Implementation
{
    internal class ConvolutionFormEventBinderWrapper
        : IConvolutionFormEventBinderWrapper
    {
        public ConvolutionFormEventBinderWrapper(
            IEventAggregatorWrapper aggregator)
        {

        }

        public virtual void OnElementExpose(IConvolutionFormExposer form)
        {

        }


        public bool ProcessCmdKey(IConvolutionFormExposer view, Keys keyData)
        {
            throw new NotImplementedException();
        }
    }
}
