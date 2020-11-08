using System.Windows.Forms;

using ImageProcessing.App.UILayer.FormExposers.Distribution;

namespace ImageProcessing.App.UILayer.FormEventBinders.Distribution.Interface
{
    internal interface IDistributionFormEventBinder : IFormEventBinder<IDistributionFormExposer>
    {
        public bool ProcessCmdKey(IDistributionFormExposer view, Keys keyData);
    }
}
