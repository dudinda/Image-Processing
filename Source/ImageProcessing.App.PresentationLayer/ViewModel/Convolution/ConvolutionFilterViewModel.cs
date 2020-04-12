using System.Drawing;

using ImageProcessing.App.Common.Helpers;

namespace ImageProcessing.App.PresentationLayer.ViewModel.Convolution
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
