using System.Windows.Forms;

using ImageProcessing.App.UILayer.Services.FormExposers;

namespace ImageProcessing.App.UILayer.Services.FormEventBinders.Rgb
{
    internal interface IRgbFormEventBinder : IFormExposer<IRgbFormExposer>
    {
        bool ProcessCmdKey(IRgbFormExposer view, Keys keyData);
    }
}
