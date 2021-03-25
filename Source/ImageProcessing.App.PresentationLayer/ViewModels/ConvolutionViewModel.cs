using System.Drawing;

namespace ImageProcessing.App.PresentationLayer.ViewModels
{
    internal sealed class ConvolutionViewModel
    {
        public ConvolutionViewModel(Bitmap source)
            => Source = source;
       
        public Bitmap Source { get; set; }
    }
}
