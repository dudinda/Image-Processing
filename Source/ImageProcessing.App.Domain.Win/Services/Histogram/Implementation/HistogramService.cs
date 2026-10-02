using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Win.Providers.VisitableFactory.Histogram;
using ImageProcessing.App.Domain.Win.Providers.Visitors.Histogram;

namespace ImageProcessing.App.Domain.Win.Services.Histogram.Implementation
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
