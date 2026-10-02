using System.Collections.Concurrent;
using System.Drawing;

namespace ImageProcessing.App.Presentation.ViewModels
{
    internal sealed class QualityMeasureViewModel
    {
        public QualityMeasureViewModel(ConcurrentQueue<Bitmap> queue)
        {
            Queue = queue;
        }
    
        public ConcurrentQueue<Bitmap> Queue { get; }

    }
}
