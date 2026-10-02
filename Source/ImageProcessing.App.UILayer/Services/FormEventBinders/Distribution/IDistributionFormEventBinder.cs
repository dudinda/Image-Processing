using System.Windows.Forms;

using ImageProcessing.App.UILayer.Services.FormExposers;

namespace ImageProcessing.App.UILayer.Services.FormEventBinders.Distribution
{
    internal interface IDistributionFormEventBinder : IFormExposer<IDistributionFormExposer>
    {
        bool ProcessCmdKey(IDistributionFormExposer view, Keys keyData);
    }
}
