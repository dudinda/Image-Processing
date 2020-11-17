using System.Windows.Forms;

using ImageProcessing.App.UILayer.FormEventBinders;
using ImageProcessing.App.UILayer.FormExposer.Transformation;

namespace ImageProcessing.App.UILayer.FormEventBinder.Transformation.Interface
{
    internal interface ITransformationFormEventBinder : IFormEventBinder<ITransformationFormExposer>
    {
        bool ProcessCmdKey(ITransformationFormExposer view, Keys keyData);
    }
}
