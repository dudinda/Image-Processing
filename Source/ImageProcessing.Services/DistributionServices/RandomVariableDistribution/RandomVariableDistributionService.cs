using System;
using System.Linq;

using ImageProcessing.Core.Model.Distribution;
using ImageProcessing.Services.DistributionServices.Distribution.Interface;

namespace ImageProcessing.Services.DistributionServices.RandomVariableDistribution.Implementation
{
    //ptr[0] - B, ptr[1] - G, ptr[2] - R
    public partial class RandomVariableDistributionService : IRandomVariableDistributionService
    {
        public decimal[] TransformTo(decimal[] cdf, IDistribution distribution)
        {
            if(cdf is null)
            {
                throw new ArgumentNullException(nameof(cdf));
            }

            if(distribution is null)
            {
                throw new ArgumentNullException(nameof(distribution));
            }

            //get new pixel values, according to a selected distribution
            return TransformToImpl(cdf, distribution);
        }

        public decimal GetExpectation(decimal[] pmf)
        {
            if (pmf is null)
            {
                throw new ArgumentNullException(nameof(pmf));
            }

            if(pmf.Any(value => value < 0))
            {
                throw new ArgumentException("Probability mass function is always positive.");
            }

            if(!pmf.Sum().Equals(1))
            {
                throw new ArgumentException("The pmf must be normalized.");
            }

            return GetExpectationImpl(pmf);
        }

        public decimal GetVariance(decimal[] pmf)
        {
            if(pmf is null)
            {
                throw new ArgumentNullException(nameof(pmf));
            }

            if (pmf.Any(value => value < 0))
            {
                throw new ArgumentException("Probability mass function is always positive.");
            }

            if (!pmf.Sum().Equals(1))
            {
                throw new ArgumentException("The pmf must be normalized.");
            }

            return GetVarianceImpl(pmf);
        }

        public decimal GetStandardDeviation(decimal[] pmf)
        {
            if(pmf is null)
            {
                throw new ArgumentNullException(nameof(pmf));
            }

            if (pmf.Any(value => value < 0))
            {
                throw new ArgumentException("Probability mass function is always positive.");
            }

            if (!pmf.Sum().Equals(1))
            {
                throw new ArgumentException("The pmf must be normalized.");
            }

            return GetStandardDeviationImpl(pmf);
        }

        public decimal GetConditionalExpectation((int x1, int x2) interval, decimal[] pmf)
        {
           if(pmf is null)
            {
                throw new ArgumentNullException(nameof(pmf));
            }

            if (pmf.Any(value => value < 0))
            {
                throw new ArgumentException("Probability mass function is always positive.");
            }

            if (!pmf.Sum().Equals(1))
            {
                throw new ArgumentException("The pmf must be normalized.");
            }

            return GetConditionalExpectationImpl(interval, pmf);
        }

        public decimal GetConditionalVariance((int x1, int x2) interval, decimal[] frequencies)
        {
            if(frequencies is null)
            {
                throw new ArgumentNullException(nameof(frequencies));
            }

            if (frequencies.Any(value => value < 0))
            {
                throw new ArgumentException("Frequencies are always positive.");
            }

            return GetConditionalVarianceImpl(interval, frequencies);
        }

        public decimal[] GetCDF(decimal[] pmf)
        {
            if(pmf is null)
            {
                throw new ArgumentNullException(nameof(pmf));
            }

            if (pmf.Any(value => value < 0))
            {
                throw new ArgumentException("Probability mass function is always positive.");
            }

            if (!pmf.Sum().Equals(1))
            {
                throw new ArgumentException("The pmf must be normalized.");
            }

            return GetCDFImpl(pmf);
        }

        public decimal[] GetPMF(int[] frequencies)
        {
            if(frequencies is null)
            {
                throw new ArgumentNullException(nameof(frequencies));
            }

            if (frequencies.Any(value => value < 0))
            {
                throw new ArgumentException("Frequencies are always positive.");
            }


            return GetPMFImpl(frequencies);
        }

        public decimal GetEntropy(decimal[] pmf)
        {
            if(pmf is null)
            {
                throw new ArgumentNullException(nameof(pmf));
            }

            if (pmf.Any(value => value < 0))
            {
                throw new ArgumentException("Probability mass function is always positive.");
            }

            if (!pmf.Sum().Equals(1))
            {
                throw new ArgumentException("The pmf must be normalized.");
            }

            return GetEntropyImpl(pmf);
        }

    
    }

}

