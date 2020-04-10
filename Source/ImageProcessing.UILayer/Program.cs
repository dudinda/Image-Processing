using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EntryPoint;
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
                AppStart.BuildContainer(DiContainer.Ninject);
                AppStart.UseStartup<Startup>();
                AppStart.Run<MainPresenter>();
            }
            catch(Exception ex)
            {
                AppStart.Exit();
            }
        }
    }
}
