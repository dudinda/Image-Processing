using System.Drawing;

using ImageProcessing.Common.Helpers;

namespace ImageProcessing.PresentationLayer.ViewModel.Convolution
{
    internal sealed class ConvolutionFilterViewModel
    {
        public ConvolutionFilterViewModel(Bitmap source)
        {
            Source = Requires.IsNotNull(
                source, nameof(source));
        }

        public Bitmap Source { get; }
    }
}
