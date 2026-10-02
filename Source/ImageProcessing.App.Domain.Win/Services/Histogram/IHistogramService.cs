using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.Domain.Code.Enums;

namespace ImageProcessing.App.Domain.Win.Services.Histogram
{
    public interface IHistogramService
    {
        (Series Plot, decimal Max) BuildPlot(RndFunction function, Bitmap bmp);
    }
}
