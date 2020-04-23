using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.ServiceLayer.Builders.ChartBuilder.Interface;

namespace ImageProcessing.App.ServiceLayer.Builders.ChartBuilder.Implementation
{
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
           
        public IChartSeriesBuilder SetName(string name)
        {
            _name = name;
            return this;
        }
           
        public IChartSeriesBuilder SetColor(Color color)
        {
            _color = color;
            return this;
        }
           
        public IChartSeriesBuilder SetLegendVisibility(bool isVisible)
        {
            _IsVisibleInLegend = isVisible;
            return this;
        }
             
        public IChartSeriesBuilder SetChartType(SeriesChartType chartType)
        {
            _chartType = chartType;
            return this;
        }
            

        public IChartSeriesBuilder SetMarkerStyle(MarkerStyle markerStyle)
        {
            _markerStyle = markerStyle;
            return this;
        }
            

        public IChartSeriesBuilder SetBorderWidth(int borderWidth)
        {
            _borderWidth = borderWidth;
            return this;
        }

        public IChartSeriesBuilder SetBorderColor(Color color)
        {
            _borderColor = color;
            return this;
        }

        public IChartSeriesBuilder SetLabelAngle(int labelAngle)
        {
            _labelAngle = labelAngle;
            return this;
        }

        public Series Build()
        {
            var series = new Series(_name);

            series.Color = _color;
            series.BorderColor = _borderColor;
            series.IsVisibleInLegend = _IsVisibleInLegend;
            series.ChartType = _chartType;
            series.MarkerStyle = _markerStyle;
            series.BorderWidth = _borderWidth;
            series.LabelAngle = _labelAngle;

            return series;
        }
        
    }
}
