using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Helpers;

namespace ImageProcessing.App.PresentationLayer.ViewModel.Histogram
{
    internal sealed class HistogramViewModel
    {
        public HistogramViewModel(Bitmap source, RandomVariableFunction mode)
        {
            Source = Requires.IsNotNull(
                source, nameof(source));

            Mode = mode;
        }

        public Bitmap Source { get; }
        public RandomVariableFunction Mode { get; }
    }
}
