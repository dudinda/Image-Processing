using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.Controls
{
    public partial class SelectedAreaControl : MetroUserControl
    {

        private Color _penColor = Color.Black;
        private float _penWidth = 4.0f;

        public SelectedAreaControl()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
            InitializeComponent();
        }

        [Description("Color of the rectangle"), Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(true)]
        public Color PenColor
        {
            get => _penColor;
        }

        [Description("Thickness of the rectangle"), Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(true)]
        public float PenWidth
        {
            get => _penWidth;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using var pen = new Pen(PenColor, PenWidth);

            var boxStart = TopLeft.Location;
            var boxEnd = new Point(boxStart.X + TopLeft.Width, boxStart.Y + TopLeft.Height);
            var xCenter = (boxStart.X + boxEnd.X) / 2;
            var yCenter = (boxStart.Y + boxEnd.Y) / 2;

            e.Graphics.DrawRectangle(pen,
                new Rectangle(xCenter, yCenter, TopRight.Location.X - boxStart.X, BottomLeft.Location.Y - boxStart.Y));
        }
    }
}
