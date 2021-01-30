using System.Drawing;

namespace ImageProcessing.App.PresentationLayer.ViewModels.ColorMatrix
{
    internal sealed class ColorMatrixViewModel
    {
        public ColorMatrixViewModel(Bitmap source)
        {
            Source = source;
        }

        public Bitmap Source { get; set; }
    }
}
