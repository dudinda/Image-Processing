using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.ServiceLayer.Builders.ChartBuilder.Interface;
using ImageProcessing.App.ServiceLayer.Services.Distribution.BitmapLuminance.Interface;
using ImageProcessing.App.ServiceLayer.Services.QualityMeasure.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.QualityMeasure.Implementation
{
    public sealed class QualityMeasureService : IQualityMeasureService
    {
        private readonly IBitmapLuminanceService _distributionService;
        private readonly IChartSeriesBuilder _builder;

        public QualityMeasureService(
            IBitmapLuminanceService distibutionService,
            IChartSeriesBuilder builder)
        {
            _distributionService = distibutionService;
            _builder = builder;
        }

        public Dictionary<string, Series> BuildIntervals(ConcurrentQueue<Bitmap> queue)
        {
            var result = new Dictionary<string, Series>();

            var random = new Random(Guid.NewGuid().GetHashCode());

            while (queue.TryDequeue(out var bitmap))
            {
                var variance = new List<decimal>();
                var names = new List<string>();

                for (var graylevel = 0; graylevel < 255; graylevel += 15)
                {
                    names.Add($"{graylevel}-{graylevel + 15}");
                    variance.Add(_distributionService.GetConditionalVariance((graylevel, graylevel + 15), bitmap));
                }

                var key = bitmap.Tag.ToString();

                _builder.SetName(key)
                        .SetColor(Color.FromArgb(random.Next(0, 256),
                                                 random.Next(0, 256),
                                                 random.Next(0, 256))
                        )
                        .SetMarkerStyle(MarkerStyle.None)
                        .SetChartType(SeriesChartType.Column)
                        .SetLabelAngle(-90)
                        .SetVisibleInLegend(true);

                var series = _builder.Build();
                series.Points.DataBindXY(names, variance);

                result.Add(key, series);

                bitmap.Dispose();
            }

            return result;
        }
    }
}
