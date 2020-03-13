using System.Drawing;

using ImageProcessing.Common.Helpers;
using ImageProcessing.Core.Model.Distribution;
using ImageProcessing.ServiceLayer.Service.DistributionServices.BitmapLuminanceDistribution.Interface;
using ImageProcessing.ServiceLayer.Services.DistributionServices.BitmapLuminanceDistribution.Abstract;

namespace ImageProcessing.ServiceLayer.Services.DistributionServices.BitmapLuminanceDistribution
{
    public class BitmapLuminanceDistributionService : BitmapLuminanceDistributionServiceImplementation, IBitmapLuminanceDistributionService
    {
        public Bitmap TransformTo(Bitmap bitmap, IDistribution distribution)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));
            Requires.IsNotNull(distribution, nameof(distribution));

            return TransformToImpl(bitmap, distribution);
        }

        public decimal GetExpectation(Bitmap bitmap)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));

            return GetExpectationImpl(bitmap);
        }

        public decimal GetVariance(Bitmap bitmap)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));

            return GetVarianceImpl(bitmap);
        }

        public decimal GetStandardDeviation(Bitmap bitmap)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));

            return GetStandardDeviationImpl(bitmap);
        }

        public decimal GetConditionalExpectation((int x1, int x2) interval, Bitmap bitmap)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));

            return GetConditionalExpectationImpl(interval, bitmap);
        }

        public decimal GetConditionalVariance((int x1, int x2) interval, Bitmap bitmap)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));

            return GetConditionalVarianceImpl(interval, bitmap);
        }

        public int[] GetFrequencies(Bitmap bitmap)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));

            return GetFrequenciesImpl(bitmap);
        }

        public decimal[] GetCDF(Bitmap bitmap)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));

            return GetCDFImpl(bitmap);
        }

        public decimal[] GetPMF(Bitmap bitmap)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));

            return GetPMFImpl(bitmap);
        }

        public decimal GetEntropy(Bitmap bmp)
        {
            Requires.IsNotNull(bmp, nameof(bmp));

            return GetEntropyImpl(bmp);
        } 
    }
}