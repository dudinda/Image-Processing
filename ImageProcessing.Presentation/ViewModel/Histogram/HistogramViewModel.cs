using ImageProcessing.Common.Enums;

using System.Drawing;

namespace ImageProcessing.Presentation.ViewModel.Histogram
{
    public class HistogramViewModel
    {
        public Bitmap Source { get; }

        public RandomVariableAction Mode { get; }

        public HistogramViewModel(Bitmap source, RandomVariableAction mode)
        {
            Source = source;
            Mode   = mode;
        }
    }
}
