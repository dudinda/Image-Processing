using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.EnumExt;
using ImageProcessing.App.ServiceLayer.Builders.ChartBuilder.Interface;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitors.Histogram.Interface;
using ImageProcessing.App.ServiceLayer.Services.Distribution.BitmapLuminance.Interface;

namespace ImageProcessing.App.ServiceLayer.ServiceModel.Visitors.Histogram.Implementation
{
    public sealed class HistogramVisitor : IHistogramVisitor
    {
        private readonly IChartSeriesBuilder _builder;
        private readonly IBitmapLuminanceDistributionService _service;

        public HistogramVisitor(
            IChartSeriesBuilder builder,
            IBitmapLuminanceDistributionService service)
        {
            _builder = builder;
            _service = service;
        }

        public (Series Series, decimal Max) BuildCdf(Bitmap bmp)
        {
            var series = _builder
                .SetName(RndFunction.CDF.GetDescription())
                .SetChartType(SeriesChartType.StepLine)
                .SetColor(Color.Red)
                .SetBorderWidth(1)
                .SetVisibleInLegend(true)
                .Build();

            return BuildSeries(series, _service.GetCDF(bmp));
        }

        public (Series Series, decimal Max) BuildPmf(Bitmap bmp)
        {
            var series = _builder
                .SetName(RndFunction.PMF.GetDescription())
                .SetColor(Color.Blue)
                .SetChartType(SeriesChartType.Column)
                .SetVisibleInLegend(true)
                .Build();

            return BuildSeries(series, _service.GetPMF(bmp));
        }

        private (Series, decimal) BuildSeries(Series series, decimal[] function)
        {
            for (int graylevel = 0; graylevel < 256; ++graylevel)
            {
                series.Points.AddXY(graylevel, function[graylevel]);
            }

            return (series, function.Max());
        }
    }
}
