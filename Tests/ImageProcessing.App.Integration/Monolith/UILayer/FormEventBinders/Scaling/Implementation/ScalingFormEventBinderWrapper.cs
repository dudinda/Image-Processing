using System.Windows.Forms;

using ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.Scaling.Interface;
using ImageProcessing.App.Presentation.UnitTests.Fakes.Components;
using ImageProcessing.App.UI.Services.FormEventBinders.Scaling.Implementation;
using ImageProcessing.App.UI.Services.FormExposers;

namespace ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.Scaling.Implementation
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
