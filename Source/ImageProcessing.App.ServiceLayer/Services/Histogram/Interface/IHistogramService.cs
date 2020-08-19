using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.ServiceLayer.Services.Histogram.Interface
{
    internal interface IHistogramService
    {
        (Series Plot, decimal Max) BuildPlot(RandomVariableFunction function, Bitmap bmp);
    }
}
