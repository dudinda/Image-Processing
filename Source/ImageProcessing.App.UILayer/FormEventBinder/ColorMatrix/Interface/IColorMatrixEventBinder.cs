using System.Windows.Forms;

using ImageProcessing.App.UILayer.FormEventBinders;
using ImageProcessing.App.UILayer.FormExposer.ColorMatrix;

namespace ImageProcessing.App.UILayer.FormEventBinder.ColorMatrix.Interface
{
    internal interface IColorMatrixEventBinder : IFormEventBinder<IColorMatrixFormExposer>
    {
        bool ProcessCmdKey(IColorMatrixFormExposer view, Keys keyData);
    }
}
