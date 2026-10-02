using System.Windows.Forms;

using ImageProcessing.App.UI.Services.FormExposers;

namespace ImageProcessing.App.UI.Services.FormEventBinders.ColorMatrix
{
    internal interface IColorMatrixFormEventBinder : IFormExposer<IColorMatrixFormExposer>
    {
        bool ProcessCmdKey(IColorMatrixFormExposer view, Keys keyData);
    }
}
