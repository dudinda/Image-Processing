using ImageProcessing.Core.Model.Distribution;

namespace ImageProcessing.Services.DistributionServices.Distribution.Interface
{
    public interface IRandomVariableDistributionService
    {
        double[] TransformTo(double[] cdf, IDistribution distribution);
        double GetEntropy(double[] pmf);
        double GetExpectation(double[] pmf);
        double GetVariance(double[] pmf);
        double GetStandardDeviation(double[] pmf);
        double[] GetPMF(int[] frequencies, uint total);
        double[] GetCDF(double[] pmf);
        double GetConditionalExpectation((int x1, int x2) interval, double[] pmf);
        double GetConditionalVariance((int x1, int x2) interval, double[] pmf);
    }
}
