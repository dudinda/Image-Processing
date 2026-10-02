using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.Domain.Providers.Visitable;
using ImageProcessing.App.Domain.Win.Providers.Visitors.Histogram;

namespace ImageProcessing.App.Domain.Win.Providers.Visitable.Histogram
{
    public interface IHistogramVisitable : IVisitable<IHistogramVisitable, IHistogramVisitor>
    {
        (Series Series, decimal Max) BuildHistogram(Bitmap bmp);
    }
}
