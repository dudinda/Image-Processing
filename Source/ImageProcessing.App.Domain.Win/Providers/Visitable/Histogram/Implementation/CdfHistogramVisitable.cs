using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.Domain.Win.Providers.Visitors.Histogram;

namespace ImageProcessing.App.Domain.Win.Providers.Visitable.Histogram.Implementation
{
    public sealed class CdfHistogramVisitable : IHistogramVisitable
    {
        private IHistogramVisitor? _visitor;

        public IHistogramVisitable Accept(IHistogramVisitor visitor)
        {
            _visitor = visitor;
            return this;
        }

        public (Series Series, decimal Max) BuildHistogram(Bitmap bmp)
            => _visitor?.BuildCdf(bmp) ?? throw new ArgumentException(nameof(_visitor));
    }
}
