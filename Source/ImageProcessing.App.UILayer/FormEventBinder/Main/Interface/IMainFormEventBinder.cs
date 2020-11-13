using System.Windows.Forms;

using ImageProcessing.App.UILayer.FormExposers.Main;

namespace ImageProcessing.App.UILayer.FormEventBinders.Main.Interface
{
    internal interface IMainFormEventBinder : IFormEventBinder<IMainFormExposer>
    {
        public bool ProcessCmdKey(IMainFormExposer view, Keys keyData);
    }
}