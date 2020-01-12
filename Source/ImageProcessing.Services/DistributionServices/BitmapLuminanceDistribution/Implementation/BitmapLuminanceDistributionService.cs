using System;
using System.Drawing;

using ImageProcessing.Distributions.Abstract;
using ImageProcessing.Services.DistributionServices.BitmapLuminanceDistribution.Interface;
using ImageProcessing.Services.DistributionServices.Distribution.Implementation;

namespace ImageProcessing.Services.DistributionServices.BitmapLuminanceDistribution.Implementation
{
    public partial class BitmapLuminanceDistributionService : DistributionService, IBitmapLuminanceDistributionService
    {
        public Bitmap TransformTo(Bitmap bitmap, IDistribution distribution)
        {
            if (bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            if (distribution is null)
            {
                throw new ArgumentNullException(nameof(distribution));
            }

            return TransformTo(bitmap, distribution);
        }

        public double GetExpectation(Bitmap bitmap)
        {
            if (bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            return GetExpectationImpl(bitmap);
        }

        public double GetVariance(Bitmap bitmap)
        {
            if (bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            return GetVarianceImpl(bitmap);
        }

        public double GetStandardDeviation(Bitmap bitmap)
        {
            if (bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            return GetStandardDeviationImpl(bitmap);
        }

        public double GetConditionalExpectation((int x1, int x2) interval, Bitmap bitmap)
        {
            if (bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            return GetConditionalExpectationImpl(interval, bitmap);
        }

        public double GetConditionalVariance((int x1, int x2) interval, Bitmap bitmap)
        {
            if (bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            return GetConditionalVarianceImpl(interval, bitmap);
        }

        public int[] GetFrequencies(Bitmap bitmap)
        {
            if (bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            return GetFrequenciesImpl(bitmap);
        }

        public double[] GetCDF(Bitmap bitmap)
        {
            if (bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            return GetCDFImpl(bitmap);
        }

        public double[] GetPMF(Bitmap bitmap)
        {
            if (bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            return GetPMFImpl(bitmap);
        }

        public double GetEntropy(Bitmap bmp)
        {
            if (bmp is null)
            {
                throw new ArgumentNullException(nameof(bmp));
            }

            return GetEntropyImpl(bmp);
        } 
    }
}
