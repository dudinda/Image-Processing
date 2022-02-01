using System;
using System.Drawing;
using System.Windows.Forms;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.Controls
{
    public sealed partial class BitmapWithRulerControl : MetroUserControl
    {
        private const int WM_HSCROLL = 0x114;
        private const int WM_VSCROLL = 0x115;
        private const int WM_MOUSEWHEEL = 0x20A;

        public bool DrawRuler { get; set; } = true;

        public PictureBox Container
            => SourceContainer;

        public BitmapWithRulerControl()
        {
            InitializeComponent();
            SourceContainer.Invalidated += (sender, args) => Invalidate();
            SourceContainer.Location = new Point(Padding.Left, Padding.Top);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (SourceContainer.Image != null && DrawRuler)
            {
                using var pen = new Pen(Color.Black, 1);
                using var font = new Font("Times New Roman", 16, FontStyle.Regular, GraphicsUnit.Pixel);
                
                var xScroll = Math.Abs(AutoScrollPosition.X);
                var yScroll = Math.Abs(AutoScrollPosition.Y);

                var step = xScroll;

                if (yScroll < Padding.Top)
                {
                    for (var x = Padding.Left; x < Container.Width + Padding.Left; ++x, ++step)
                    {
                        if (step % 100 == 0)
                        {
                            e.Graphics.DrawString(step.ToString(), font, Brushes.Black, new PointF(x + 5, 10));
                            e.Graphics.DrawLine(pen, x, 40, x, 10);
                            continue;
                        }

                        if (step % 50 == 0)
                        {
                            e.Graphics.DrawLine(pen, x, 40, x, 20);
                            continue;
                        }

                        if (step % 10 == 0)
                        {
                            e.Graphics.DrawLine(pen, x, 40, x, 30);
                            continue;
                        }
                    }
                }

                step = yScroll;

                if (xScroll < Padding.Left)
                {
                    for (var y = Padding.Top; y < Container.Height + Padding.Top; ++y, ++step)
                    {
                        if (step % 100 == 0)
                        {
                            e.Graphics.DrawString(step.ToString(), font, Brushes.Black, new PointF(0, y + 5));
                            e.Graphics.DrawLine(pen, 40, y, 10, y);
                            continue;
                        }

                        if (step % 50 == 0)
                        {
                            e.Graphics.DrawLine(pen, 40, y, 20, y);
                            continue;
                        }

                        if (step % 10 == 0)
                        {
                            e.Graphics.DrawLine(pen, 40, y, 30, y);
                            continue;
                        }
                    }
                }
            }
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_VSCROLL || m.Msg == WM_HSCROLL || m.Msg == WM_MOUSEWHEEL)
            {
                Invalidate();
            }
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }
    }
}
