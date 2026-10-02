using System.Windows.Forms;

using ImageProcessing.App.UI.Services.FormExposers;

namespace ImageProcessing.App.UI.Services.FormEventBinders.Convolution
{
    internal interface IConvolutionFormEventBinder : IFormExposer<IConvolutionFormExposer>
    {
        bool ProcessCmdKey(IConvolutionFormExposer view, Keys keyData);
    }
}
