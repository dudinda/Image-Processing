using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.ChartSeries.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Distribution.BitmapLuminance.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.QualityMeasure.Interface;
using ImageProcessing.App.ServiceLayer.Win.Services.QualityMeasure.Implementation;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.QualityMeasure.Implementation
{
    internal class QualityMeasureServiceWrapper : IQualityMeasureServiceWrapper
    {
        private readonly QualityMeasureService _service;

        public IBitmapLuminanceServiceWrapper BitmapLuminance { get; }
        public IChartSeriesBuilderWrapper ChartSeries { get; }


        public QualityMeasureServiceWrapper(
            IBitmapLuminanceServiceWrapper lum, 
            IChartSeriesBuilderWrapper builder)
        {
            BitmapLuminance = lum;
            ChartSeries = builder;
            _service = new QualityMeasureService(lum, builder);
        }

        public virtual Dictionary<string, Series> BuildIntervals(ConcurrentQueue<Bitmap> queue)
            => _service.BuildIntervals(queue);
    }
}
