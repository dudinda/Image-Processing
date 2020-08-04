using System.Windows.Forms;

using ImageProcessing.App.UILayer.FormControls.Base;
using ImageProcessing.App.UILayer.FormElements.Main;

namespace ImageProcessing.App.UILayer.EventBinders.Main.Interface
{
    internal interface IMainElementEventBinder : IElementEventBinder<IMainElementExposer>
    {
        public bool ProcessCmdKey(IMainElementExposer view, Keys keyData);
    }
}
