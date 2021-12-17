using System.Windows.Forms;

using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Distribution.Interface;
using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Components;
using ImageProcessing.App.UILayer.FormEventBinders.Distribution.Implementation;
using ImageProcessing.App.UILayer.FormExposers.Distribution;

namespace ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Distribution.Implementation
{
    internal class DistributionFormEventBinderWrapper : IDistributionFormEventBinderWrapper
    {
        private readonly DistributionFormEventBinder _binder;

        public DistributionFormEventBinderWrapper(
            IEventAggregatorWrapper aggregator)
        {
            _binder = new DistributionFormEventBinder(aggregator);
        }

        public virtual void OnElementExpose(IDistributionFormExposer form)
        {
            _binder.OnElementExpose(form);
        }

        public virtual bool ProcessCmdKey(IDistributionFormExposer view, Keys keyData)
        {
            return _binder.ProcessCmdKey(view, keyData);
        }
    }
}
