using System.Windows.Forms;

using ImageProcessing.App.UI.Services.FormExposers;

namespace ImageProcessing.App.UI.Services.FormEventBinders.Distribution
{
    internal interface IDistributionFormEventBinder : IFormExposer<IDistributionFormExposer>
    {
        bool ProcessCmdKey(IDistributionFormExposer view, Keys keyData);
    }
}
