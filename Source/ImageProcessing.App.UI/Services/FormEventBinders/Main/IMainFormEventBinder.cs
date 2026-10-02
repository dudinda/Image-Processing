using System.Windows.Forms;

using ImageProcessing.App.UI.Services.FormExposers;

namespace ImageProcessing.App.UI.Services.FormEventBinders.Main
{
    internal interface IMainFormEventBinder : IFormExposer<IMainFormExposer>
    {
        bool ProcessCmdKey(IMainFormExposer view, Keys keyData);
    }
}
