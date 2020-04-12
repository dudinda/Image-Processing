using System;

using ImageProcessing.Framework.Core.DI.Code.Enums;
using ImageProcessing.EntryPoint;
using ImageProcessing.EntryPoint.Code.Enums;
using ImageProcessing.App.PresentationLayer.Presenters.Main;

namespace ImageProcessing.App.UILayer
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
