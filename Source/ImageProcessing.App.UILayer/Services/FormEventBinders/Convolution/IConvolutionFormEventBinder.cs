using System.Windows.Forms;

using ImageProcessing.App.UILayer.Services.FormExposers;

namespace ImageProcessing.App.UILayer.Services.FormEventBinders.Convolution
{
    internal interface IConvolutionFormEventBinder : IFormExposer<IConvolutionFormExposer>
    {
        bool ProcessCmdKey(IConvolutionFormExposer view, Keys keyData);
    }
}
