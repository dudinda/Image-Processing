using System.Windows.Forms;

namespace ImageProcessing.App.UI.Code.Extensions
{
    public static class ControlExtensions
    {
        extension(Control control)
        {
            public void Enable(bool isEnabled)
            {
                if (control != null)
                {
                    foreach (Control c in control.Controls)
                    {
                        c.Enable(isEnabled);
                    }
                    control.Enabled = isEnabled;
                }
            }
        }
    }
}
