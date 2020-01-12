using System.Drawing;
using System;

using ImageProcessing.Distributions.Abstract;

namespace ImageProcessing.Services.Distribution
{
    //ptr[0] - B, ptr[1] - G, ptr[2] - R
    public partial class DistributionService : IDistributionService
    {
        public Bitmap Distribute(Bitmap bitmap, IDistribution distribution)
        {
            if(bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            if(distribution is null)
            {
                throw new ArgumentNullException(nameof(distribution));
            }

            return DistributeImpl(bitmap, distribution);
        }

        public double GetExpectation(double[] pmf)
        {
            if(pmf is null)
            {
                throw new ArgumentNullException(nameof(pmf));
            }

            return GetExpectationImpl(pmf);
        }

        public double GetExpectation(Bitmap bitmap)
        {
            if(bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            return GetExpectationImpl(bitmap);
        }

        public double GetVariance(double[] pmf)
        {
            if(pmf is null)
            {
                throw new ArgumentNullException(nameof(pmf));
            }

            return GetVarianceImpl(pmf);
        }

        public double GetVariance(Bitmap bitmap)
        {
            if(bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            return GetVarianceImpl(bitmap);
        }

        public double GetStandardDeviation(double[] pmf)
        {
            if(pmf is null)
            {
                throw new ArgumentNullException(nameof(pmf));
            }

            return GetStandardDeviationImpl(pmf);
        }

        public double GetStandardDeviation(Bitmap bitmap)
        {
            if(bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            return GetStandardDeviationImpl(bitmap);
        }

        public double GetConditionalExpectation(int x1, int x2, double[] pmf)
        {
           if(pmf is null)
            {
                throw new ArgumentNullException(nameof(pmf));
            }

            return GetConditionalExpectationImpl(x1, x2, pmf);
        }

        public double GetConditionalVariance(int x1, int x2, double[] frequencies)
        {
            if(frequencies is null)
            {
                throw new ArgumentNullException(nameof(frequencies));
            }

            return GetConditionalVarianceImpl(x1, x2, frequencies);
        }

        public int[] GetFrequencies(Bitmap bitmap)
        {          
           if(bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            return GetFrequenciesImpl(bitmap);
        }

        public double[] GetCDF(double[] pmf)
        {
            if(pmf is null)
            {
                throw new ArgumentNullException(nameof(pmf));
            }

            return GetCDFImpl(pmf);
        }

        public double[] GetPMF(int[] frequencies, double resolution)
        {
            if(frequencies is null)
            {
                throw new ArgumentNullException(nameof(frequencies));
            }

            return GetPMFImpl(frequencies, resolution);
        }

        public double GetEntropy(Bitmap bmp)
        {
            if(bmp is null)
            {
                throw new ArgumentNullException(nameof(bmp));
            }

            return GetEntropyImpl(bmp);
        }


        private byte[] Transform(double[] cdf, IDistribution distribution)
        {
            if(cdf is null)
            {
                throw new ArgumentNullException(nameof(cdf));
            }

            if(distribution is null)
            {
                throw new ArgumentNullException(nameof(distribution));
            }

            return TransformImpl(cdf, distribution);
        }
    
    }

}

