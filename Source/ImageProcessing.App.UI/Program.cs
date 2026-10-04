using System;

using ImageProcessing.App.Presentation.Presenters;
using ImageProcessing.Microkernel;
using ImageProcessing.Microkernel.MVP.Code.Enums;

namespace ImageProcessing.App.UI
{
    internal static class Program
    {    
        [STAThread]
        internal static void Main()
        {
            try
            {
                AppLifecycle.Build<Startup>(DiContainer.Ninject);
                AppLifecycle.Run<MainPresenter>();
            }
            catch(Exception ex)
            {
                AppLifecycle.Exit();
            }
        }
    }
}
