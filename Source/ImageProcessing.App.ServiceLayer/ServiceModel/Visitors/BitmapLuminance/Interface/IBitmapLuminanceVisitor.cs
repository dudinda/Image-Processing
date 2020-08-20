using System.Drawing;

namespace ImageProcessing.App.ServiceLayer.ServiceModel.Visitors.BitmapLuminance.Interface
{
    internal interface IBitmapLuminanceVisitor
    {
        decimal GetVariance(Bitmap bmp);
        decimal GetEntropy(Bitmap bmp);
        decimal GetExpectation(Bitmap bmp);
        decimal GetStandardDeviation(Bitmap bmp);
    }
}
