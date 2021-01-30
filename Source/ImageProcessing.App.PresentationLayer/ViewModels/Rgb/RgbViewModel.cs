using System.Drawing;

namespace ImageProcessing.App.PresentationLayer.ViewModels.Rgb
{
    internal sealed class RgbViewModel
    {
        public RgbViewModel(Bitmap source)
        {
            Source = source;
        }

        public Bitmap Source { get; set; }
    }
}
