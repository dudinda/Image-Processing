using System.Runtime.CompilerServices;
using System.Windows.Forms;

using ImageProcessing.App.PresentationLayer.UnitTests.Services;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.TestsComponents.Extensions
{
    internal static class ButtonExtensions
    {
        public static void ClickAndWaitSignal(this ToolStripItem button, IAutoResetEventService synchronizer)
        {
            button.PerformClick();
            synchronizer.WaitSignal();
        }
    }
}
