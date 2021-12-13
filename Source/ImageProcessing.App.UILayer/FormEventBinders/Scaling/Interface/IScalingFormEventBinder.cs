using System.Windows.Forms;

using ImageProcessing.App.UILayer.FormExposers;

namespace ImageProcessing.App.UILayer.FormEventBinders.Scaling.Interface
{
    internal interface IScalingFormEventBinder : IFormExposer<IScalingFormExposer>
    {
        bool ProcessCmdKey(IScalingFormExposer view, Keys keyData);
    }
}
