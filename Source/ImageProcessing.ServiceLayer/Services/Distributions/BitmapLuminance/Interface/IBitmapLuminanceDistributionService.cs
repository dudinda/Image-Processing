using System.Drawing;

using ImageProcessing.DomainModel.Model.Distributions.Interface;

namespace ImageProcessing.ServiceLayer.Services.Distributions.BitmapLuminance.Interface
{
    public interface IBitmapLuminanceDistributionService
    {
        Bitmap Transform(Bitmap bitmap, IDistribution distribution);
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
