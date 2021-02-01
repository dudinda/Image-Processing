using System.Windows.Forms;

using ImageProcessing.App.UILayer.FormExposers.ColorMatrix;

namespace ImageProcessing.App.UILayer.FormEventBinders.ColorMatrix.Interface
{
    internal interface IColorMatrixEventBinder : IFormEventBinder<IColorMatrixFormExposer>
    {
        bool ProcessCmdKey(IColorMatrixFormExposer view, Keys keyData);
    }
}
