using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.ServiceLayer.Builders.ChartBuilder.Interface;

namespace ImageProcessing.App.ServiceLayer.Builders.ChartBuilder.Implementation
{
    public sealed class ChartSeriesBuilder : IChartSeriesBuilder
    {
        private string _name;
        private Color _color;
        private bool _IsVisibleInLegend;
        private SeriesChartType _type;
        private MarkerStyle _style;
        private int _width;
        private Color _borderColor;
           
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
             
        public IChartSeriesBuilder SetChartType(SeriesChartType type)
        {
            _type = type;
            return this;
        }
            

        public IChartSeriesBuilder SetMarkerStyle(MarkerStyle style)
        {
            _style = style;
            return this;
        }
            

        public IChartSeriesBuilder SetBorderWidth(int width)
        {
            _width = width;
            return this;
        }

        public IChartSeriesBuilder SetBorderColor(Color color)
        {
            _borderColor = color;
            return this;
        }

        public Series Build()
        {
            var series = new Series(_name);

                series.Color             = _color;
                series.BorderColor       = _borderColor;
                series.IsVisibleInLegend = _IsVisibleInLegend;
                series.ChartType         = _type;
                series.MarkerStyle       = _style;
                series.BorderWidth       = _width;

            return series;
        }
        
    }
}
