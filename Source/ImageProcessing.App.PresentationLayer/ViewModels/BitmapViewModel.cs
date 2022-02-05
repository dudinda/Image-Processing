using System.Drawing;

namespace ImageProcessing.App.PresentationLayer.ViewModels
{
    internal sealed class BitmapViewModel
    {
        public BitmapViewModel(Rectangle area)
        {
            Area = area;
        }

        public Rectangle Area { get; set; }
    }
}
