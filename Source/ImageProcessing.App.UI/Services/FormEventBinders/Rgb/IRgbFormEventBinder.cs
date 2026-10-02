using System.Windows.Forms;

using ImageProcessing.App.UI.Services.FormExposers;

namespace ImageProcessing.App.UI.Services.FormEventBinders.Rgb
{
    internal interface IRgbFormEventBinder : IFormExposer<IRgbFormExposer>
    {
        bool ProcessCmdKey(IRgbFormExposer view, Keys keyData);
    }
}
