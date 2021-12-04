using System.Drawing;

namespace ImageProcessing.App.PresentationLayer.ViewModels
{
    internal sealed class BitmapViewModel
    {
        public BitmapViewModel(Bitmap source)
        {
            Source = source;
        }

        public Bitmap Source { get; set; }
    }
}
