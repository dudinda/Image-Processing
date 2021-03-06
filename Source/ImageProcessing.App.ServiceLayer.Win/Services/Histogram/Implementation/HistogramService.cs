using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Win.ServiceModel.VisitableFactory.Histogram.Interface;
using ImageProcessing.App.ServiceLayer.Win.ServiceModel.Visitors.Histogram.Interface;
using ImageProcessing.App.ServiceLayer.Win.Services.Histogram.Interface;

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
