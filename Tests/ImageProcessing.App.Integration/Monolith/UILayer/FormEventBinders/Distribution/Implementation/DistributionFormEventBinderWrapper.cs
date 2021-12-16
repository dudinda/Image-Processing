using System.Windows.Forms;

using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Distribution.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Distribution.Interface;
using ImageProcessing.App.UILayer.FormExposers.Distribution;

namespace ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Distribution.Implementation
{
    internal class DistributionFormEventBinderWrapper : IDistributionFormEventBinderWrapper
    {
        private readonly IDistributionFormEventBinder _binder;

        public DistributionFormEventBinderWrapper(
            IDistributionFormEventBinder binder)
        {
            _binder = binder;
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
