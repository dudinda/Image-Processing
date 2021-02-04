using System.Windows.Forms;

using ImageProcessing.App.UILayer.FormExposers;
using ImageProcessing.App.UILayer.FormExposers.Distribution;

namespace ImageProcessing.App.UILayer.FormEventBinders.Distribution.Interface
{
    internal interface IDistributionFormEventBinder : IFormExposer<IDistributionFormExposer>
    {
        bool ProcessCmdKey(IDistributionFormExposer view, Keys keyData);
    }
}
