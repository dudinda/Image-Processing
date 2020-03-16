using System;

using ImageProcessing.Common.Enums;

namespace ImageProcessing.UILayer
{
    internal static class Program
    {
        [STAThread]
        internal static void Main()
        {
            try
            {
                Startup.Build(Container.Ninject);
                Startup.Run();
            }
            catch(Exception ex)
            {
                Startup.Exit();
            }
        }
    }
}
