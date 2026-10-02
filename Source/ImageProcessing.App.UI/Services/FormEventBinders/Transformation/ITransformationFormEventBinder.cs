using System.Windows.Forms;

using ImageProcessing.App.UI.Services.FormExposers;

namespace ImageProcessing.App.UI.Services.FormEventBinders.Transformation
{
    internal interface ITransformationFormEventBinder : IFormExposer<ITransformationFormExposer>
    {
        bool ProcessCmdKey(ITransformationFormExposer view, Keys keyData);
    }
}
