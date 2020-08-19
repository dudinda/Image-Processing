using System.Drawing;

namespace ImageProcessing.App.ServiceLayer.Visitors.BitmapLuminance.Visitor.Interface
{
    internal interface IBitmapLuminanceVisitor
    {
        decimal GetVariance(Bitmap bmp);
        decimal GetEntropy(Bitmap bmp);
        decimal GetExpectation(Bitmap bmp);
        decimal GetStandardDeviation(Bitmap bmp);
    }
}
