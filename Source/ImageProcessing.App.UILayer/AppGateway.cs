using System;

using ImageProcessing.App.PresentationLayer.Presenters;
using ImageProcessing.Microkernel.DIAdapter.Code.Enums;
using ImageProcessing.Microkernel.EntryPoint;

namespace ImageProcessing.App.UILayer
{
    internal static class AppGateway
    {    
        [STAThread]
        internal static void Main()
        {
            try
            {
                AppLifecycle.Build<UIStartup>(DiContainer.Ninject);
                AppLifecycle.Run<MainPresenter>();
            }
            catch(Exception ex)
            {
                AppLifecycle.Exit();
            }
        }
    }
}
