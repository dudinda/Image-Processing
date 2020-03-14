using ImageProcessing.DomainModel.Model.Distributions.Interface;

namespace ImageProcessing.ServiceLayer.Services.Distributions.RandomVariable.Interface
{
    public interface IRandomVariableDistributionService
    {
        decimal[] TransformToDecimal(decimal[] cdf, IDistribution distribution);
        byte[] TransformToByte(decimal[] cdf, IDistribution distribution);
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
