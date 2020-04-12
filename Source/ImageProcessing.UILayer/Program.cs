using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.EntryPoint;
using ImageProcessing.EntryPoint.Code.Enums;
using ImageProcessing.PresentationLayer.Presenters.Main;

namespace ImageProcessing.UILayer
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
                AppLifecycle.SetState(AppState.EndWork);
                AppLifecycle.Exit();
            }
        }
    }
}
