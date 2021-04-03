using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.App.ServiceLayer.ServiceModel.Visitable;
using ImageProcessing.App.ServiceLayer.Win.ServiceModel.Visitors.Histogram.Interface;

namespace ImageProcessing.App.ServiceLayer.Win.ServiceModel.Visitable.Histogram
{
    public interface IHistogramVisitable : IVisitable<IHistogramVisitable, IHistogramVisitor>
    {
        (Series Series, decimal Max) BuildHistogram(Bitmap bmp);
    }
}
