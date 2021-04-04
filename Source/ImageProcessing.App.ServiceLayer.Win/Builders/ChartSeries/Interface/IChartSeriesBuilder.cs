using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace ImageProcessing.App.ServiceLayer.Win.Builders.ChartBuilder.Interface
{
    /// <summary>
    /// A builder for the <see cref="Series"/> components.
    /// </summary>
    public interface IChartSeriesBuilder : IBuilder<Series>
    {
        /// <summary>
        /// Set the series name.
        /// </summary>
        IChartSeriesBuilder SetName(string name);

        /// <summary>
        /// Set the series color.
        /// </summary>
        IChartSeriesBuilder SetColor(Color color);

        /// <summary>
        /// Set the series chart type.
        /// </summary>
        IChartSeriesBuilder SetChartType(SeriesChartType chartType);

        /// <summary>
        /// Set the series marker style.
        /// </summary>
        IChartSeriesBuilder SetMarkerStyle(MarkerStyle markerStyle);

        /// <summary>
        /// Set the series border width.
        /// </summary>
        IChartSeriesBuilder SetBorderWidth(int borderWidth);

        /// <summary>
        /// Set the series border color.
        /// </summary>
        IChartSeriesBuilder SetBorderColor(Color color);

        /// <summary>
        /// Set the series angle label.
        /// </summary>
        IChartSeriesBuilder SetLabelAngle(int labelAngle);

        /// <summary>
        /// Set the series visibility in the legend.
        /// </summary>
        IChartSeriesBuilder SetVisibleInLegend(bool isVisibleInLegend);
    }
}
