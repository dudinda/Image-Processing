using System.Collections.Concurrent;
using System.Drawing;

namespace ImageProcessing.PresentationLayer.ViewModel.QualityMeasure
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