using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.ServiceLayer.Builders.Base;

namespace ImageProcessing.App.ServiceLayer.Builders.ChartBuilder.Interface
{
    public interface IChartSeriesBuilder : IBuilder<Series>
    {
        IChartSeriesBuilder SetName(string name);
        IChartSeriesBuilder SetColor(Color color);
        IChartSeriesBuilder SetLegendVisibility(bool isVisible);
        IChartSeriesBuilder SetChartType(SeriesChartType chartType);
        IChartSeriesBuilder SetMarkerStyle(MarkerStyle markerStyle);
        IChartSeriesBuilder SetBorderWidth(int borderWidth);
        IChartSeriesBuilder SetBorderColor(Color color);
        IChartSeriesBuilder SetLabelAngle(int labelAngle);
    }
}
