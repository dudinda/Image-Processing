using System.Collections.Concurrent;
using System.Drawing;

namespace ImageProcessing.Presentation.ViewModel.QualityMeasure
{
    public sealed class QualityMeasureViewModel
    {
        public QualityMeasureViewModel(ConcurrentQueue<Bitmap> queue)
        {
            Queue = queue;
        }

        public ConcurrentQueue<Bitmap> Queue { get; }

    }
}
