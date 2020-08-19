using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.ServiceLayer.ServiceModel.Visitors.Histogram.Interface;

namespace ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.Histogram.Cdf
{
    internal sealed class CdfHistogramVisitable : IHistogramVisitable
    {
        private IHistogramVisitor _visitor = null!;

        public IHistogramVisitable Accept(IHistogramVisitor visitor)
        {
            _visitor = visitor;
            return this;
        }

        public (Series Series, decimal Max) BuildHistogram(Bitmap bmp)
            => _visitor?.BuildCdf(bmp) ?? throw new ArgumentException(nameof(_visitor));
    }
}
