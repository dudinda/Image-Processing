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
            Startup.App.Build(Container.LightInject).Run();
        }
    }
}
