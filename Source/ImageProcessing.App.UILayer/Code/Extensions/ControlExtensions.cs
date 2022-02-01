using System.Windows.Forms;

namespace ImageProcessing.App.UILayer.Code.Extensions
{
    public static class ControlExtensions
    {
        public static void Enable(this Control con, bool isEnabled)
        {
            if (con != null)
            {
                foreach (Control c in con.Controls)
                {
                    c.Enable(isEnabled);
                }

                con.Enabled = isEnabled;
            }
        }

    }
}
