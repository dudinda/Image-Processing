using System;

using ImageProcessing.Core.Model.Distribution;
using ImageProcessing.Services.DistributionServices.Distribution.Interface;

namespace ImageProcessing.Services.DistributionServices.RandomVariableDistribution.Implementation
{
    //ptr[0] - B, ptr[1] - G, ptr[2] - R
    public partial class RandomVariableDistributionService : IRandomVariableDistributionService
    {
        public double[] TransformTo(double[] cdf, IDistribution distribution)
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


        public double GetExpectation(double[] pmf)
        {
            if (pmf is null)
            {
                throw new ArgumentNullException(nameof(pmf));
            }

            return GetExpectationImpl(pmf);
        }

        public double GetVariance(double[] pmf)
        {
            if(pmf is null)
            {
                throw new ArgumentNullException(nameof(pmf));
            }

            return GetVarianceImpl(pmf);
        }

        public double GetStandardDeviation(double[] pmf)
        {
            if(pmf is null)
            {
                throw new ArgumentNullException(nameof(pmf));
            }

            return GetStandardDeviationImpl(pmf);
        }

        public double GetConditionalExpectation((int x1, int x2) interval, double[] pmf)
        {
           if(pmf is null)
            {
                throw new ArgumentNullException(nameof(pmf));
            }

            return GetConditionalExpectationImpl(interval, pmf);
        }

        public double GetConditionalVariance((int x1, int x2) interval, double[] frequencies)
        {
            if(frequencies is null)
            {
                throw new ArgumentNullException(nameof(frequencies));
            }

            return GetConditionalVarianceImpl(interval, frequencies);
        }

        public double[] GetCDF(double[] pmf)
        {
            if(pmf is null)
            {
                throw new ArgumentNullException(nameof(pmf));
            }

            return GetCDFImpl(pmf);
        }

        public double[] GetPMF(int[] frequencies, uint total)
        {
            if(frequencies is null)
            {
                throw new ArgumentNullException(nameof(frequencies));
            }

            return GetPMFImpl(frequencies, total);
        }

        public double GetEntropy(double[] pmf)
        {
            if(pmf is null)
            {
                throw new ArgumentNullException(nameof(pmf));
            }

            return GetEntropyImpl(pmf);
        }

    
    }

}

