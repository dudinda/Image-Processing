using System.Windows.Forms;

using ImageProcessing.App.UILayer.FormExposers;
using ImageProcessing.App.UILayer.FormExposers.ColorMatrix;

namespace ImageProcessing.App.UILayer.FormEventBinders.ColorMatrix.Interface
{
    internal interface IColorMatrixFormEventBinder : IFormExposer<IColorMatrixFormExposer>
    {
        bool ProcessCmdKey(IColorMatrixFormExposer view, Keys keyData);
    }
}
