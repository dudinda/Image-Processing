using System.Drawing;

using ImageProcessing.Common.Enums;

namespace ImageProcessing.Presentation.ViewModel.Histogram
{
    public class HistogramViewModel
    {
        public HistogramViewModel(Bitmap source, RandomVariableAction mode)
        {
            Source = source;
            Mode   = mode;
        }

        public Bitmap Source { get; }
        public RandomVariableAction Mode { get; }
    }
}
