using System.Drawing;

using ImageProcessing.Distributions.Abstract;

namespace ImageProcessing.Services.Distribution
{
    public interface IDistributionService
    {
        Bitmap Distribute(Bitmap bitmap, IDistribution distribution);
        double GetExpectation(double[] pmf);
        double GetExpectation(Bitmap bitmap);
        double GetVariance(double[] pmf);
        double GetVariance(Bitmap bitmap);
        double GetStandardDeviation(double[] pmf);
        double GetStandardDeviation(Bitmap bitmap);
        double GetConditionalExpectation(int x1, int x2, double[] pmf);
        double GetConditionalVariance(int x1, int x2, double[] frequencies);
        int[] GetFrequencies(Bitmap bitmap);
        double[] GetCDF(double[] pmf);
        double[] GetPMF(int[] frequencies, double resolution);
        double GetEntropy(Bitmap bmp);
    }
}
