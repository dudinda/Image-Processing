using System.Windows.Forms;

using ImageProcessing.App.UI.Services.FormExposers;

namespace ImageProcessing.App.UI.Services.FormEventBinders.Rotation
{
    internal interface IRotationFormEventBinder : IFormExposer<IRotationFormExposer>
    {
        bool ProcessCmdKey(IRotationFormExposer view, Keys keyData);
    }
}
