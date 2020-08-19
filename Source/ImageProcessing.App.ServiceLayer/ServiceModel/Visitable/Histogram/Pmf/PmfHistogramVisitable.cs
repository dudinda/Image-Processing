using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.ServiceLayer.ServiceModel.Visitors.Histogram.Interface;

namespace ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.Histogram.Pmf
{
    internal sealed class PmfHistogramVisitable : IHistogramVisitable
    {
        private IHistogramVisitor _visitor = null!;

        public IHistogramVisitable Accept(IHistogramVisitor visitor)
        {
            _visitor = visitor;
            return this;
        }

        public (Series Series, decimal Max) BuildHistogram(Bitmap bmp)
            => _visitor?.BuildPmf(bmp) ?? throw new ArgumentNullException(nameof(_visitor));   
    }
}
