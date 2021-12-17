using System.Windows.Forms;

using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Rgb.Interface;
using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Components;
using ImageProcessing.App.UILayer.FormEventBinders.Rgb.Implementation;
using ImageProcessing.App.UILayer.FormExposers.Rgb;

namespace ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Rgb.Implementation
{
    internal class RgbFormEventBinderWrapper : IRgbFormEventBinderWrapper
    {
        private readonly RgbFormEventBinder _binder;

        public RgbFormEventBinderWrapper(
            IEventAggregatorWrapper aggregator)
        {
            _binder = new RgbFormEventBinder(aggregator);
        }

        public virtual void OnElementExpose(IRgbFormExposer form)
        {
            _binder.OnElementExpose(form);
        }

        public virtual bool ProcessCmdKey(IRgbFormExposer view, Keys keyData)
        {
            return _binder.ProcessCmdKey(view, keyData);
        }
    }
}
