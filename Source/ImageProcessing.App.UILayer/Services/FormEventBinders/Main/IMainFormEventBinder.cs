using System.Windows.Forms;

using ImageProcessing.App.UILayer.Services.FormExposers;

namespace ImageProcessing.App.UILayer.Services.FormEventBinders.Main
{
    internal interface IMainFormEventBinder : IFormExposer<IMainFormExposer>
    {
        bool ProcessCmdKey(IMainFormExposer view, Keys keyData);
    }
}
