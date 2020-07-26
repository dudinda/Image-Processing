using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace ImageProcessing.App.ServiceLayer.Services.Histogram.Interface
{
    public interface IHistogramService
    {
        (Series Plot, decimal Max) BuildPlot(string key, Bitmap bmp);
    }
}
