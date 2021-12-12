using System.Windows.Forms;

using ImageProcessing.App.UILayer.FormExposers;

namespace ImageProcessing.App.UILayer.FormEventBinders.Rotation.Interface
{
    internal interface IRotationFormEventBinder : IFormExposer<IRotationFormExposer>
    {
        bool ProcessCmdKey(IRotationFormExposer view, Keys keyData);
    }
}
