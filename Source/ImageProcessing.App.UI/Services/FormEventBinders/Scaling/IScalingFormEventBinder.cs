using System.Windows.Forms;

using ImageProcessing.App.UI.Services.FormExposers;

namespace ImageProcessing.App.UI.Services.FormEventBinders.Scaling
{
    internal interface IScalingFormEventBinder : IFormExposer<IScalingFormExposer>
    {
        bool ProcessCmdKey(IScalingFormExposer view, Keys keyData);
    }
}
