using System.Windows.Forms;

using ImageProcessing.App.UILayer.FormExposers.Convolution;

namespace ImageProcessing.App.UILayer.FormEventBinders.Convolution.Interface
{
    interface IConvolutionFormEventBinder : IFormEventBinder<IConvolutionFormExposer>
    {
        public bool ProcessCmdKey(IConvolutionFormExposer view, Keys keyData);
    }
}
