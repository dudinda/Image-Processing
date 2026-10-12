using System.Drawing;
using System.Drawing.Drawing2D;

namespace ImageProcessing.App.Domain.Models.Options
{
    public class PenOptions
    {
        public Color Color { get; set; }
        public int Width { get; set; }
        public DashStyle DashStyle { get; set; }
    }
}
