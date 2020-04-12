using System.Drawing;

using ImageProcessing.App.Common.Enums;
using ImageProcessing.App.Common.Helpers;

namespace ImageProcessing.App.PresentationLayer.ViewModel.Histogram
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
