using System;
using System.Threading.Tasks;

using ImageProcessing.App.PresentationLayer.Presenters.Main;
using ImageProcessing.Microkernel;
using ImageProcessing.Microkernel.DI.Code.Enums;

namespace ImageProcessing.App.UILayer
{
    internal static class Program
    {
        [STAThread]
        internal static async Task Main()
        {
            try
            {
                AppLifecycle.Build<Startup>(DiContainer.Ninject);

                await AppLifecycle
                    .Run<MainPresenter>()
                    .ConfigureAwait(true);
            }
            catch(Exception ex)
            {
                AppLifecycle.Exit();
            }
        }
    }
}
