
using System.Drawing;
using System.Windows.Forms;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.Controls
{
    public partial class BitmapWithRulerControl : MetroUserControl
    {
        public BitmapWithRulerControl()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using var pen = new Pen(Color.Black, 1);
            using var font = new Font("Times New Roman", 16, FontStyle.Regular, GraphicsUnit.Pixel);
            var step = 0;

            for (var x = Padding.Left; x < ParentPanel.Width - Padding.Right; ++x, ++step)
            {
                if (step % 100 == 0)
                {
                    e.Graphics.DrawString(step.ToString(), font, Brushes.Black, new PointF(x + 5, 10));
                    e.Graphics.DrawLine(pen, x, 40, x, 10);
                    e.Graphics.DrawLine(pen, 40, x, 10, x);
                    continue;
                }

                if (step % 50 == 0)
                {
                    e.Graphics.DrawLine(pen, x, 40, x, 20);
                    e.Graphics.DrawLine(pen, 40, x, 20, x);
                    continue;
                }

                if (step % 10 == 0)
                {
                    e.Graphics.DrawLine(pen, x, 40, x, 30);
                    e.Graphics.DrawLine(pen, 40, x, 30, x);
                    continue;
                }
            }
        }
    }
}
