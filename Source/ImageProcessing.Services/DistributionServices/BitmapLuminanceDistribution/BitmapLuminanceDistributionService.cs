using System;
using System.Drawing;

using ImageProcessing.Core.Model.Distribution;
using ImageProcessing.Services.DistributionServices.BitmapLuminanceDistribution.Interface;
using ImageProcessing.Services.DistributionServices.RandomVariableDistribution.Implementation;

namespace ImageProcessing.Services.DistributionServices.BitmapLuminanceDistribution.Implementation
{
    public partial class BitmapLuminanceDistributionService : RandomVariableDistributionService, IBitmapLuminanceDistributionService
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

        public decimal GetExpectation(Bitmap bitmap)
        {
            if (bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            return GetExpectationImpl(bitmap);
        }

        public decimal GetVariance(Bitmap bitmap)
        {
            if (bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            return GetVarianceImpl(bitmap);
        }

        public decimal GetStandardDeviation(Bitmap bitmap)
        {
            if (bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            return GetStandardDeviationImpl(bitmap);
        }

        public decimal GetConditionalExpectation((int x1, int x2) interval, Bitmap bitmap)
        {
            if (bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            return GetConditionalExpectationImpl(interval, bitmap);
        }

        public decimal GetConditionalVariance((int x1, int x2) interval, Bitmap bitmap)
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

        public decimal[] GetCDF(Bitmap bitmap)
        {
            if (bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            return GetCDFImpl(bitmap);
        }

        public decimal[] GetPMF(Bitmap bitmap)
        {
            if (bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            return GetPMFImpl(bitmap);
        }

        public decimal GetEntropy(Bitmap bmp)
        {
            if (bmp is null)
            {
                throw new ArgumentNullException(nameof(bmp));
            }

            return GetEntropyImpl(bmp);
        } 
    }
}
