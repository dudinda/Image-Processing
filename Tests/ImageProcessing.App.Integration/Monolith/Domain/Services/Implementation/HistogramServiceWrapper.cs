using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.Integration.Monolith.Domain.Services.Histogram.Interface;
using ImageProcessing.App.Domain.Code.Enums;

namespace ImageProcessing.App.Integration.Monolith.Domain.Services.Histogram.Implementation
{
    internal class HistogramServiceWrapper : IHistogramServiceWrapper
    {

        public virtual (Series Plot, decimal Max) BuildPlot(RndFunction function, Bitmap bmp)
        {
            throw new System.NotImplementedException();
        }
    }
}
