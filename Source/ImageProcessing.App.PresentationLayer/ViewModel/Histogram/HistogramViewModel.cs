using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.PresentationLayer.ViewModel.Histogram
{
    internal sealed class HistogramViewModel
    {
        public HistogramViewModel(Bitmap source, RandomVariableFunction mode)
        {
            Source = source;
            Mode = mode;
        }

        public Bitmap Source { get; }
        public RandomVariableFunction Mode { get; }
    }
}
