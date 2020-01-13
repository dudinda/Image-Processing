using System.Drawing;

using ImageProcessing.Core.Model.Distribution;

namespace ImageProcessing.Services.DistributionServices.BitmapLuminanceDistribution.Interface
{
    public interface IBitmapLuminanceDistributionService
    {
        Bitmap TransformTo(Bitmap bitmap, IDistribution distribution);
        int[] GetFrequencies(Bitmap bitmap);
        double GetExpectation(Bitmap bitmap);
        double GetVariance(Bitmap bitmap);
        double[] GetCDF(Bitmap bitmap);
        double GetEntropy(Bitmap bitmap);
        double[] GetPMF(Bitmap bitmap);
        double GetStandardDeviation(Bitmap bitmap);
        double GetConditionalExpectation((int x1, int x2) interval, Bitmap bitmap);
        double GetConditionalVariance((int x1, int x2) interval, Bitmap bitmap);
    }
}
