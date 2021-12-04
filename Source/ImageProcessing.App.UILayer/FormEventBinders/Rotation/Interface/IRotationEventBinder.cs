using System.Windows.Forms;

using ImageProcessing.App.UILayer.FormExposers;

namespace ImageProcessing.App.UILayer.FormEventBinders.Rotation.Interface
{
    internal interface IRotationEventBinder : IFormExposer<IRotationFormExposer>
    {
        bool ProcessCmdKey(IRotationFormExposer view, Keys keyData);
    }
}
