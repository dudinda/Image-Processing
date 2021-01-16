using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace ImageProcessing.App.ServiceLayer.Services.QualityMeasure.Interface
{
    public interface IQualityMeasureService
    {
        Dictionary<string, Series> BuildIntervals(ConcurrentQueue<Bitmap> queue);
    }
}
