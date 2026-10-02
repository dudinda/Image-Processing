using System.Windows.Forms;

using ImageProcessing.App.UILayer.Services.FormExposers;

namespace ImageProcessing.App.UILayer.Services.FormEventBinders.ColorMatrix
{
    internal interface IColorMatrixFormEventBinder : IFormExposer<IColorMatrixFormExposer>
    {
        bool ProcessCmdKey(IColorMatrixFormExposer view, Keys keyData);
    }
}
