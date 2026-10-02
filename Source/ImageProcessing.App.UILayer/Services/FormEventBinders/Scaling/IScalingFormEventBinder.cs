using System.Windows.Forms;

using ImageProcessing.App.UILayer.Services.FormExposers;

namespace ImageProcessing.App.UILayer.Services.FormEventBinders.Scaling
{
    internal interface IScalingFormEventBinder : IFormExposer<IScalingFormExposer>
    {
        bool ProcessCmdKey(IScalingFormExposer view, Keys keyData);
    }
}
