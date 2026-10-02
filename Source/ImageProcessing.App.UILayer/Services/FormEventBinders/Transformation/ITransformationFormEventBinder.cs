using System.Windows.Forms;

using ImageProcessing.App.UILayer.Services.FormExposers;

namespace ImageProcessing.App.UILayer.Services.FormEventBinders.Transformation
{
    internal interface ITransformationFormEventBinder : IFormExposer<ITransformationFormExposer>
    {
        bool ProcessCmdKey(ITransformationFormExposer view, Keys keyData);
    }
}
