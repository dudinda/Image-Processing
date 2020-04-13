using System;

using ImageProcessing.App.PresentationLayer.Presenters.Main;
using ImageProcessing.Framework.Core.DI.Code.Enums;
using ImageProcessing.Framework.EntryPoint;
using ImageProcessing.Framework.EntryPoint.Code.Enums;

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
