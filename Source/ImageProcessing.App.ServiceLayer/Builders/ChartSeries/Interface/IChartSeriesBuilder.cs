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
        IChartSeriesBuilder SetChartType(SeriesChartType type);
        IChartSeriesBuilder SetMarkerStyle(MarkerStyle style);
        IChartSeriesBuilder SetBorderWidth(int width);
        IChartSeriesBuilder SetBorderColor(Color color);
    }
}
