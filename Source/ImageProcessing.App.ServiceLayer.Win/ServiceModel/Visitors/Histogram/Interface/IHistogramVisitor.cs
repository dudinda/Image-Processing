using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace ImageProcessing.App.ServiceLayer.ServiceModel.Visitors.Histogram.Interface
{
    public interface IHistogramVisitor 
    {
        (Series Series, decimal Max) BuildPmf(Bitmap bmp);
        (Series Series, decimal Max) BuildCdf(Bitmap bmp);
    }
}
