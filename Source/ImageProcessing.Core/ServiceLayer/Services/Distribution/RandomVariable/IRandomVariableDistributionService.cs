using ImageProcessing.Core.Model.Distribution;

namespace ImageProcessing.ServiceLayer.Services.DistributionServices.Distribution.Interface
{
    public interface IRandomVariableDistributionService
    {
        decimal[] TransformTo(decimal[] cdf, IDistribution distribution);
        decimal GetEntropy(decimal[] pmf);
        decimal GetExpectation(decimal[] pmf);
        decimal GetVariance(decimal[] pmf);
        decimal GetStandardDeviation(decimal[] pmf);
        decimal[] GetPMF(int[] frequencies);
        decimal[] GetCDF(decimal[] pmf);
        decimal GetConditionalExpectation((int x1, int x2) interval, decimal[] pmf);
        decimal GetConditionalVariance((int x1, int x2) interval, decimal[] pmf);
    }
}
