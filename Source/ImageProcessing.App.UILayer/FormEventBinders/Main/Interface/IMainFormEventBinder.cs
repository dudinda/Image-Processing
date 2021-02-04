using System.Windows.Forms;

using ImageProcessing.App.UILayer.FormExposers;
using ImageProcessing.App.UILayer.FormExposers.Main;

namespace ImageProcessing.App.UILayer.FormEventBinders.Main.Interface
{
    internal interface IMainFormEventBinder : IFormExposer<IMainFormExposer>
    {
        bool ProcessCmdKey(IMainFormExposer view, Keys keyData);
    }
}
