
using System.Windows.Forms;

using ImageProcessing.App.UILayer.FormControls.Base;
using ImageProcessing.App.UILayer.FormControls.Rgb;

namespace ImageProcessing.App.UILayer.EventBinders.Rgb.Interface
{
    internal interface IRgbEventBinder : IBaseEventBinder<IRgbElementsExposer>
    {
        public bool ProcessCmdKey(IRgbElementsExposer view, Keys keyData);
    }
}
