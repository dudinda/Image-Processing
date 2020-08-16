using System.Drawing;

namespace ImageProcessing.App.PresentationLayer.ViewModel.Convolution
{
    internal sealed class ConvolutionViewModel
    {
        public ConvolutionViewModel(Bitmap source)
            => Source = source;
       
        public Bitmap Source { get; }
    }
}
