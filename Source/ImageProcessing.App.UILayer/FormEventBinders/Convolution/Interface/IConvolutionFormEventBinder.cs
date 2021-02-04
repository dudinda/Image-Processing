using System.Windows.Forms;

using ImageProcessing.App.UILayer.FormExposers;
using ImageProcessing.App.UILayer.FormExposers.Convolution;

namespace ImageProcessing.App.UILayer.FormEventBinders.Convolution.Interface
{
    internal interface IConvolutionFormEventBinder : IFormExposer<IConvolutionFormExposer>
    {
        bool ProcessCmdKey(IConvolutionFormExposer view, Keys keyData);
    }
}
