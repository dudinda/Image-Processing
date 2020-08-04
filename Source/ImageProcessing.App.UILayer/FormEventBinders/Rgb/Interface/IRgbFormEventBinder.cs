
using System.Windows.Forms;

using ImageProcessing.App.UILayer.Exposers.Rgb;

namespace ImageProcessing.App.UILayer.FormEventBinders.Rgb.Interface
{
    internal interface IRgbFormEventBinder : IFormEventBinder<IRgbFormExposer>
    {
        public bool ProcessCmdKey(IRgbFormExposer view, Keys keyData);
    }
}
