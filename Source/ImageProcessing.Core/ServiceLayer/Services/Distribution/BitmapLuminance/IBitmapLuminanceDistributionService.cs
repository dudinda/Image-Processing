using System.Drawing;

using ImageProcessing.Core.Model.Distribution;

namespace ImageProcessing.ServiceLayer.Service.DistributionServices.BitmapLuminanceDistribution.Interface
{
    public interface IBitmapLuminanceDistributionService
    {
        Bitmap TransformTo(Bitmap bitmap, IDistribution distribution);
        int[] GetFrequencies(Bitmap bitmap);
        decimal GetExpectation(Bitmap bitmap);
        decimal GetVariance(Bitmap bitmap);
        decimal[] GetCDF(Bitmap bitmap);
        decimal GetEntropy(Bitmap bitmap);
        decimal[] GetPMF(Bitmap bitmap);
        decimal GetStandardDeviation(Bitmap bitmap);
        decimal GetConditionalExpectation((int x1, int x2) interval, Bitmap bitmap);
        decimal GetConditionalVariance((int x1, int x2) interval, Bitmap bitmap);
    }
}
