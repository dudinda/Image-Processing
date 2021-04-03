using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.ServiceLayer.Win.Builders.ChartBuilder.Interface;

namespace ImageProcessing.App.ServiceLayer.Win.Builders.ChartBuilder.Implementation
{
    /// <inheritdoc/>
    public sealed class ChartSeriesBuilder : IChartSeriesBuilder
    {
        private string? _name;
        private Color _color;
        private bool _IsVisibleInLegend;
        private SeriesChartType _chartType;
        private MarkerStyle _markerStyle;
        private int _borderWidth;
        private Color _borderColor;
        private int _labelAngle;
        private bool _isVisibleInLegend;

        /// <inheritdoc/>
        public IChartSeriesBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        /// <inheritdoc/>
        public IChartSeriesBuilder SetColor(Color color)
        {
            _color = color;
            return this;
        }

        /// <inheritdoc/>
        public IChartSeriesBuilder SetLegendVisibility(bool isVisible)
        {
            _IsVisibleInLegend = isVisible;
            return this;
        }

        /// <inheritdoc/>
        public IChartSeriesBuilder SetChartType(SeriesChartType chartType)
        {
            _chartType = chartType;
            return this;
        }

        /// <inheritdoc/>
        public IChartSeriesBuilder SetMarkerStyle(MarkerStyle markerStyle)
        {
            _markerStyle = markerStyle;
            return this;
        }

        /// <inheritdoc/>
        public IChartSeriesBuilder SetBorderWidth(int borderWidth)
        {
            _borderWidth = borderWidth;
            return this;
        }

        /// <inheritdoc/>
        public IChartSeriesBuilder SetBorderColor(Color color)
        {
            _borderColor = color;
            return this;
        }

        /// <inheritdoc/>
        public IChartSeriesBuilder SetLabelAngle(int labelAngle)
        {
            _labelAngle = labelAngle;
            return this;
        }

        /// <inheritdoc/>
        public IChartSeriesBuilder SetVisibleInLegend(bool isVisibleInLegend)
        {
            _isVisibleInLegend = isVisibleInLegend;
            return this;
        }

        /// <summary>
        /// Build the <see cref="Series"/>.
        /// </summary>
        public Series Build()
        {
            var series = _name is null ?
                new Series() : new Series(_name);

            series.Color = _color;
            series.BorderColor = _borderColor;
            series.IsVisibleInLegend = _IsVisibleInLegend;
            series.ChartType = _chartType;
            series.MarkerStyle = _markerStyle;
            series.BorderWidth = _borderWidth;
            series.LabelAngle = _labelAngle;
            series.IsVisibleInLegend = _isVisibleInLegend;
            return series;
        }
        
    }
}
