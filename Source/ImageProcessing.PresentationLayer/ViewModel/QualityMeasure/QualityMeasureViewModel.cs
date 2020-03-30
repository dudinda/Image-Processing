using System.Collections.Concurrent;
using System.Drawing;

using ImageProcessing.Common.Helpers;

namespace ImageProcessing.PresentationLayer.ViewModel.QualityMeasure
{
    internal sealed class QualityMeasureViewModel
    {
        public QualityMeasureViewModel(ConcurrentQueue<Bitmap> queue)
        {
            Queue = Requires.IsNotNull(
                queue, nameof(queue));
        }

        public ConcurrentQueue<Bitmap> Queue { get; }

    }
}
