using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.UI;

namespace ImageProcessing
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
