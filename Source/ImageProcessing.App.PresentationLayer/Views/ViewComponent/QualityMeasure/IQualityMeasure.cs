using System.Collections.Concurrent;
using System.Drawing;

namespace ImageProcessing.App.PresentationLayer.Views.ViewComponent.QualityMeasure
{
    public interface IQualityMeasure
    {
        bool QualityMeasureIsEnabled { get; set; }

        /// <summary>
        /// Adds an image, transformed by a distribution to
        /// the quality measure container.
        /// </summary>
        void AddToQualityMeasureContainer(Bitmap transformed);
        ConcurrentQueue<Bitmap> GetQualityQueue();
        void ClearQueue();
    }
}
