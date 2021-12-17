using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.Integration.Monolith.ServiceLayer.ServiceModel.Vistiors.Histogram.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.ChartSeries.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Distribution.BitmapLuminance.Interface;
using ImageProcessing.App.ServiceLayer.Win.ServiceModel.Visitors.Histogram.Implementation;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.ServiceModel.Vistiors.Histogram.Implementation
{
    internal class HistogramVisitorWrapper : IHistogramVisitorWrapper
    {
        private readonly HistogramVisitor _visitor;

        public IBitmapLuminanceServiceWrapper BitmapLuminance { get; }
        public IChartSeriesBuilderWrapper ChartSeries { get; }

        public HistogramVisitorWrapper(
            IBitmapLuminanceServiceWrapper service,
            IChartSeriesBuilderWrapper builder)
        {
            BitmapLuminance = service;
            ChartSeries = builder;

            _visitor = new HistogramVisitor(builder, service);
        }

        public virtual (Series Series, decimal Max) BuildPmf(Bitmap bmp)
            => _visitor.BuildPmf(bmp);

        public virtual (Series Series, decimal Max) BuildCdf(Bitmap bmp)
            => _visitor.BuildCdf(bmp);
    }
}
