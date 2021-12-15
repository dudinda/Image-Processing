using System.Windows.Forms;

using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Distribution.Interface;
using ImageProcessing.App.UILayer.FormExposers.Distribution;

namespace ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Distribution.Implementation
{
    internal class DistributionFormEventBinderWrapper : IDistributionFormEventBinderWrapper
    {
        public void OnElementExpose(IDistributionFormExposer form)
        {
            throw new System.NotImplementedException();
        }

        public bool ProcessCmdKey(IDistributionFormExposer view, Keys keyData)
        {
            throw new System.NotImplementedException();
        }
    }
}
