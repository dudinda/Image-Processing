using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.ServiceLayer.Services.Histogram.Interface
{
    public interface IHistogramService
    {
        (Series Plot, decimal Max) BuildPlot(RndFunction function, Bitmap bmp);
    }
}
