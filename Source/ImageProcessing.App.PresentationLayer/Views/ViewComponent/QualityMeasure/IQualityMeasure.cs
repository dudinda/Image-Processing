using System.Collections.Concurrent;
using System.Drawing;

namespace ImageProcessing.App.PresentationLayer.Views.ViewComponent.QualityMeasure
{
    public interface IQualityMeasure
    {
        ConcurrentQueue<Bitmap> GetQualityQueue();
        void ClearQueue();
    }
}
