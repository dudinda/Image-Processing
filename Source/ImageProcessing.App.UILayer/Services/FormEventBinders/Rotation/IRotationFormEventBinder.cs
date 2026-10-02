using System.Windows.Forms;

using ImageProcessing.App.UILayer.Services.FormExposers;

namespace ImageProcessing.App.UILayer.Services.FormEventBinders.Rotation
{
    internal interface IRotationFormEventBinder : IFormExposer<IRotationFormExposer>
    {
        bool ProcessCmdKey(IRotationFormExposer view, Keys keyData);
    }
}
