using System.Windows.Forms;

using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Scaling.Interface;
using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Components;
using ImageProcessing.App.UILayer.FormEventBinders.Scaling.Implementation;
using ImageProcessing.App.UILayer.FormExposers;

namespace ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Scaling.Implementation
{
    internal class ScalingFormEventBinderWrapper : IScalingFormEventBinderWrapper
    {
        private readonly ScalingFormEventBinder _binder;

        public ScalingFormEventBinderWrapper(
            IEventAggregatorWrapper aggregator)
        {
            _binder = new ScalingFormEventBinder(aggregator);
        }

        public virtual void OnElementExpose(IScalingFormExposer form)
        {
            _binder.OnElementExpose(form);
        }

        public virtual bool ProcessCmdKey(IScalingFormExposer view, Keys keyData)
        {
            return _binder.ProcessCmdKey(view, keyData);
        }
    }
}
