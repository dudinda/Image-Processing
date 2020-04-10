using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.EntryPoint;
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
                App.Build<Startup>(DiContainer.Ninject);
                App.Run<MainPresenter>();
            }
            catch(Exception ex)
            {
                App.Exit();
            }
        }
    }
}
