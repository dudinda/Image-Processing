using System.Drawing;

namespace ImageProcessing.Presentation.ViewModel.Convolution
{
    public class ConvolutionFilterViewModel
    {
        public ConvolutionFilterViewModel(Bitmap source)
        {
            Source = source;
        }
        public Bitmap Source { get; }
    }
}
