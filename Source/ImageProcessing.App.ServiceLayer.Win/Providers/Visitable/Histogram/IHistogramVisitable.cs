using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.ServiceLayer.Providers.Visitable;
using ImageProcessing.App.ServiceLayer.Win.Providers.Visitors.Histogram;

namespace ImageProcessing.App.ServiceLayer.Win.Providers.Visitable.Histogram
{
    public interface IHistogramVisitable : IVisitable<IHistogramVisitable, IHistogramVisitor>
    {
        (Series Series, decimal Max) BuildHistogram(Bitmap bmp);
    }
}
