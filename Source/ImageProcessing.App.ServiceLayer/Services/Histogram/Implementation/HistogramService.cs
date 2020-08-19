using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.ServiceLayer.ServiceModel.VisitableFactory.Histogram.Interface;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitors.Histogram.Interface;
using ImageProcessing.App.ServiceLayer.Services.Histogram.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.Histogram.Implementation
{
    internal sealed class HistogramService : IHistogramService
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

        public (Series Plot, decimal Max) BuildPlot(RandomVariableFunction function, Bitmap bmp)
            => _factory.Get(function).Accept(_visitor).BuildHistogram(bmp);
    } 
}
