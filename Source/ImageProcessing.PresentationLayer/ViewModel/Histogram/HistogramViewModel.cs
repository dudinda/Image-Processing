using System.Drawing;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Helpers;

namespace ImageProcessing.PresentationLayer.ViewModel.Histogram
{
    internal sealed class HistogramViewModel
    {
        public HistogramViewModel(Bitmap source, RandomVariable mode)
        {
            Source = Requires.IsNotNull(
                source, nameof(source));

            Mode = mode;
        }

        public Bitmap Source { get; }
        public RandomVariable Mode { get; }
    }
}
