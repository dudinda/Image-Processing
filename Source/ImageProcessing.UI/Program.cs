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
            Startup.Build(Container.LightInject);
            Startup.Run();
        }
    }
}
