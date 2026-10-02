using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Win.Providers.VisitableFactory.Histogram;
using ImageProcessing.App.ServiceLayer.Win.Providers.Visitors.Histogram;

namespace ImageProcessing.App.ServiceLayer.Win.Services.Histogram.Implementation
{
    public sealed class HistogramService : IHistogramService
    {
        private readonly IHistogramVisitableFactory _factory;
        private readonly IHistogramVisitor _visitor;

        public HistogramService(
            IHistogramVisitableFactory factory,
            IHistogramVisitor visitor)
        {
            _factory = factory;
            _visitor = visitor;
        }

        public (Series Plot, decimal Max) BuildPlot(RndFunction function, Bitmap bmp)
            => _factory.Get(function).Accept(_visitor).BuildHistogram(bmp);
    } 
}
