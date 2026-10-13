using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using MetroFramework.Controls;

namespace ImageProcessing.App.UI.Controls
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

        public Rectangle GetArea()
        {
            int.TryParse(TopLeft.Text, out var x);
            int.TryParse(TopRight.Text, out var y);
            int.TryParse(BottomLeft.Text, out var width);
            int.TryParse(BottomRight.Text, out var height);
            return new Rectangle(x, y, width, height);
        }

        public void SetArea(Rectangle area)
        {
            TopLeft.Text = area.X.ToString();
            TopRight.Text = area.Y.ToString();
            BottomLeft.Text = area.Width.ToString();
            BottomRight.Text = area.Height.ToString();
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
                new Rectangle(xCenter, yCenter, BottomRight.Location.X - boxStart.X, BottomRight.Location.Y - boxStart.Y));
        }
    }
}
