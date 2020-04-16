using ImageProcessing.App.DomainLayer.Model.Distributions.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.Distributions.RandomVariable.Interface
{
    /// <summary>
    /// Provides the information about
    /// the distribution of a discrete random variable.
    /// </summary>
    public interface IRandomVariableDistributionService
    {
        /// <summary>
        /// Approximate the specified cdf to
        /// a selected distribution.
        /// The new values is <see cref="decimal"/>. 
        /// </summary>
        decimal[] TransformToDecimal(decimal[] cdf, IDistribution distribution);

        /// <summary>
        /// Approximate the specified cdf to a selected distribution.
        /// The new values is in range of <see cref="byte"/>.
        /// </summary>
        /// <param name="cdf"></param>
        /// <param name="distribution"></param>
        /// <returns></returns>
        byte[] TransformToByte(decimal[] cdf, IDistribution distribution);

        /// <summary>
        /// Get entropy of
        /// the specified distribution.
        /// </summary>
        decimal GetEntropy(decimal[] pmf);

        /// <summary>
        /// Get the expected value of
        /// the specified distribution.
        /// </summary>
        decimal GetExpectation(decimal[] pmf);

        /// <summary>
        /// Get variance of the
        /// specified distribution.
        /// </summary>
        decimal GetVariance(decimal[] pmf);

        /// <summary>
        /// Get standard deviation of the
        /// specified distribution.
        /// </summary>
        decimal GetStandardDeviation(decimal[] pmf);

        /// <summary>
        /// Get the probability mass function by normalizing
        /// the frequencies.
        /// </summary>
        decimal[] GetPMF(int[] frequencies);

        /// <summary>
        /// Get the cumulative distribution function of
        /// the specified distribution.
        /// </summary>
        decimal[] GetCDF(decimal[] pmf);

        /// <summary>
        /// Get a conditional expected value on
        /// the specified interval.
        /// </summary>
        decimal GetConditionalExpectation((int x1, int x2) interval, decimal[] pmf);

        /// <summary>
        /// Get conditional variance on the
        /// specified interval.
        /// </summary>
        decimal GetConditionalVariance((int x1, int x2) interval, decimal[] pmf);
    }
}
