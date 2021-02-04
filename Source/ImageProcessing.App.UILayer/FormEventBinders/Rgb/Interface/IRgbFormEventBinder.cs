using System.Windows.Forms;

using ImageProcessing.App.UILayer.FormExposers;
using ImageProcessing.App.UILayer.FormExposers.Rgb;

namespace ImageProcessing.App.UILayer.FormEventBinders.Rgb.Interface
{
    internal interface IRgbFormEventBinder : IFormExposer<IRgbFormExposer>
    {
        bool ProcessCmdKey(IRgbFormExposer view, Keys keyData);
    }
}
