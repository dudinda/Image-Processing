
using System.Windows.Forms;

using ImageProcessing.App.UILayer.FormControls.Base;
using ImageProcessing.App.UILayer.FormControls.Rgb;

namespace ImageProcessing.App.UILayer.EventBinders.Rgb.Interface
{
    internal interface IRgbEventBinder : IBaseEventBinder<IRgbElementExposer>
    {
        public bool ProcessCmdKey(IRgbElementExposer view, Keys keyData);
    }
}
