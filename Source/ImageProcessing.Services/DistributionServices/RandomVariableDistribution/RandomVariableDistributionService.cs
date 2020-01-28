using System.Linq;

using ImageProcessing.Common.Extensions.DecimalMathRealExtensions;
using ImageProcessing.Common.Helpers;
using ImageProcessing.Core.Model.Distribution;
using ImageProcessing.DecimalMath.Real;
using ImageProcessing.Services.DistributionServices.Distribution.Interface;

namespace ImageProcessing.Services.DistributionServices.RandomVariableDistribution.Implementation
{
    //ptr[0] - B, ptr[1] - G, ptr[2] - R
    public partial class RandomVariableDistributionService : IRandomVariableDistributionService
    {
        public decimal[] TransformTo(decimal[] cdf, IDistribution distribution)
        {
            Requires.IsNotNull(cdf, nameof(cdf));
            Requires.IsNotNull(distribution, nameof(distribution));

            //get new pixel values, according to a selected distribution
            return TransformToImpl(cdf, distribution);
        }

        public decimal GetExpectation(decimal[] pmf)
        {
            Requires.IsNotNull(pmf, nameof(pmf));

            Requires.IsTrue(
                () => pmf.Any(value => value > 0),
                "Probability mass function is always positive.");

            Requires.IsTrue(
                () => (pmf.Sum() - 1.0M).Abs() < DecimalMathReal.Epsilon,
                "The pmf must be normalized.");

            return GetExpectationImpl(pmf);
        }

        public decimal GetVariance(decimal[] pmf)
        {
            Requires.IsNotNull(pmf, nameof(pmf));

            Requires.IsTrue(
                () => pmf.Any(value => value > 0),
                "Probability mass function is always positive.");

            Requires.IsTrue(
                () => (pmf.Sum() - 1.0M).Abs() < DecimalMathReal.Epsilon,
                "The pmf must be normalized.");

            return GetVarianceImpl(pmf);
        }

        public decimal GetStandardDeviation(decimal[] pmf)
        {
            Requires.IsNotNull(pmf, nameof(pmf));

            Requires.IsTrue(
                () => pmf.Any(value => value > 0),
                "Probability mass function is always positive.");

            Requires.IsTrue(
                () => (pmf.Sum() - 1.0M).Abs() < DecimalMathReal.Epsilon,
                "The pmf must be normalized.");

            return GetStandardDeviationImpl(pmf);
        }

        public decimal GetConditionalExpectation((int x1, int x2) interval, decimal[] pmf)
        {
            Requires.IsNotNull(pmf, nameof(pmf));

            Requires.IsTrue(
                () => pmf.Any(value => value > 0),
                "Probability mass function is always positive.");

            Requires.IsTrue(
                () => (pmf.Sum() - 1.0M).Abs() < DecimalMathReal.Epsilon,
                "The pmf must be normalized.");

            return GetConditionalExpectationImpl(interval, pmf);
        }

        public decimal GetConditionalVariance((int x1, int x2) interval, decimal[] frequencies)
        {

            Requires.IsNotNull(frequencies, nameof(frequencies));

            Requires.IsTrue(
                () => frequencies.Any(value => value > 0),
                "Frequencies are always positive.");

            return GetConditionalVarianceImpl(interval, frequencies);
        }

        public decimal[] GetCDF(decimal[] pmf)
        {
            Requires.IsNotNull(pmf, nameof(pmf));

            Requires.IsTrue(
                () => pmf.Any(value => value > 0),
                "Probability mass function is always positive.");

            Requires.IsTrue(
                () => (pmf.Sum() - 1.0M).Abs() < DecimalMathReal.Epsilon,
                "The pmf must be normalized.");

            return GetCDFImpl(pmf);
        }

        public decimal[] GetPMF(int[] frequencies)
        {
            Requires.IsNotNull(frequencies, nameof(frequencies));

            Requires.IsTrue(
                () => frequencies.Any(value => value > 0),
                "Frequencies are always positive.");

            return GetPMFImpl(frequencies);
        }

        public decimal GetEntropy(decimal[] pmf)
        {
            Requires.IsNotNull(pmf, nameof(pmf));

            Requires.IsTrue(
                () => pmf.Any(value => value > 0),
                "Probability mass function is always positive.");

            Requires.IsTrue(
                () => (pmf.Sum() - 1.0M).Abs() < DecimalMathReal.Epsilon,
                "The pmf must be normalized.");

            return GetEntropyImpl(pmf);
        }

    
    }

}

