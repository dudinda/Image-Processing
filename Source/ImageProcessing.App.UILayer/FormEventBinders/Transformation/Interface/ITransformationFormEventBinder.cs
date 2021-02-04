using System.Windows.Forms;

using ImageProcessing.App.UILayer.FormExposers;
using ImageProcessing.App.UILayer.FormExposers.Transformation;

namespace ImageProcessing.App.UILayer.FormEventBinders.Transformation.Interface
{
    internal interface ITransformationFormEventBinder : IFormExposer<ITransformationFormExposer>
    {
        bool ProcessCmdKey(ITransformationFormExposer view, Keys keyData);
    }
}
