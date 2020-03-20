using System.Drawing;

namespace ImageProcessing.PresentationLayer.ViewModel.Convolution
{
    public sealed class ConvolutionFilterViewModel
    {
        public ConvolutionFilterViewModel(Bitmap source)
        {
            Source = source;
        }

        public Bitmap Source { get; }
    }
}
