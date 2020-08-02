using System.Drawing;

namespace ImageProcessing.App.PresentationLayer.ViewModel.Rgb
{
    internal sealed class RgbViewModel
    {
        public RgbViewModel(Bitmap source)
        {
            Source = source;
        }

        public Bitmap Source;
    }
}
