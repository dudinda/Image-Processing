using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.CommonLayer.Attributes;
using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.EnumExt;
using ImageProcessing.App.CommonLayer.Extensions.TypeExt;
using ImageProcessing.App.ServiceLayer.Builders.ChartBuilder.Interface;
using ImageProcessing.App.ServiceLayer.Services.Distributions.BitmapLuminance.Interface;
using ImageProcessing.App.ServiceLayer.Services.Histogram.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.Histogram.Implementation
{
    public sealed class HistogramService : IHistogramService
    {
        private static readonly Dictionary<string, CommandAttribute>
          _functions = typeof(HistogramService).GetCommands();

        private readonly IBitmapLuminanceDistributionService _distributionService;
        private readonly IChartSeriesBuilder _builder;

        public HistogramService(IBitmapLuminanceDistributionService distibutionService,
                                IChartSeriesBuilder builder)
        {
            _distributionService = distibutionService;
            _builder = builder;
        }

        public (Series Plot, decimal Max) BuildPlot(string key, Bitmap bmp)
        {
            var function = GetFunction(key, bmp);

            var series = _builder.Build();

            for (int graylevel = 0; graylevel < 256; ++graylevel)
            {
                series.Points.AddXY(graylevel, function[graylevel]);
            }

            return (series, function.Max());
        }

        private decimal[] GetFunction(string key, Bitmap bmp)
            => (decimal[])_functions[key]
            .Method.Invoke(this, new[] { bmp });
        
        [Command(nameof(RandomVariableFunction.PMF))]
        private decimal[] BuildPMFCommand(Bitmap bmp)
        {
            _builder
               .SetName(RandomVariableFunction.PMF.GetDescription())
               .SetColor(Color.Blue)
               .SetChartType(SeriesChartType.Column)
               .SetVisibleInLegend(true);

            return _distributionService.GetPMF(bmp);
        }

        [Command(nameof(RandomVariableFunction.CDF))]
        private decimal[] BuildCDFCommand(Bitmap bmp)
        {
            _builder
               .SetName(RandomVariableFunction.CDF.GetDescription())
               .SetMarkerStyle(MarkerStyle.None)
               .SetChartType(SeriesChartType.StepLine)
               .SetColor(Color.Red)
               .SetVisibleInLegend(true);

            return _distributionService.GetCDF(bmp);
        }
    }
}
