using System.Collections.Concurrent;
using System.Drawing;

namespace ImageProcessing.App.PresentationLayer.ViewModels.QualityMeasure
{
    internal sealed class QualityMeasureViewModel
    {
        public QualityMeasureViewModel(ConcurrentQueue<Bitmap> queue)
            => Queue = queue;
    
        public ConcurrentQueue<Bitmap> Queue { get; }

    }
}
