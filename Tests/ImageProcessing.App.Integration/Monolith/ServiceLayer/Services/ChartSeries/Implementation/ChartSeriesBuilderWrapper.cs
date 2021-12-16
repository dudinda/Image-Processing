using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.ChartSeries.Interface;
using ImageProcessing.App.ServiceLayer.Win.Builders.ChartBuilder.Implementation;
using ImageProcessing.App.ServiceLayer.Win.Builders.ChartBuilder.Interface;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.ChartSeries.Implementation
{
    internal class ChartSeriesBuilderWrapper : IChartSeriesBuilderWrapper
    {
        private readonly ChartSeriesBuilder _builder
            = new ChartSeriesBuilder();

        public virtual Series Build()
            => _builder.Build();

        public virtual IChartSeriesBuilder SetBorderColor(Color color)
            => _builder.SetBorderColor(color);

        public virtual IChartSeriesBuilder SetBorderWidth(int borderWidth)
            => _builder.SetBorderWidth(borderWidth);

        public virtual IChartSeriesBuilder SetChartType(SeriesChartType chartType)
            => _builder.SetChartType(chartType);

        public virtual IChartSeriesBuilder SetColor(Color color)
            => _builder.SetColor(color);

        public virtual IChartSeriesBuilder SetLabelAngle(int labelAngle)
            => _builder.SetLabelAngle(labelAngle);

        public virtual IChartSeriesBuilder SetMarkerStyle(MarkerStyle markerStyle)
            => _builder.SetMarkerStyle(markerStyle);

        public virtual IChartSeriesBuilder SetName(string name)
            => _builder.SetName(name);

        public virtual IChartSeriesBuilder SetVisibleInLegend(bool isVisibleInLegend)
            => _builder.SetVisibleInLegend(isVisibleInLegend);
    }
}
