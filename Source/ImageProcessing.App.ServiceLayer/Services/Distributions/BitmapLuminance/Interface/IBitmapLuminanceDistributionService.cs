using System.Drawing;

using ImageProcessing.App.DomainModel.Model.Distributions.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.Distributions.BitmapLuminance.Interface
{
    /// <summary>
    /// Provides the information about the distribution of the pixels luminance
    /// on the specified bitmap.
    /// </summary>
    public interface IBitmapLuminanceDistributionService
    {
        /// <summary>
        /// Transform the luminance histogram of
        /// the specified bitmap to a selected distribution.
        /// </summary>
        Bitmap Transform(Bitmap bitmap, IDistribution distribution);

        /// <summary>
        /// Get frequencies of the grayscale levels.
        /// </summary>
        int[] GetFrequencies(Bitmap bitmap);

        /// <summary>
        /// Get the expected value of the pixels luminance distribution.
        /// </summary>
        decimal GetExpectation(Bitmap bitmap);

        /// <summary>
        /// Get variance of the pixels luminance diststribution.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        decimal GetVariance(Bitmap bitmap);

        /// <summary>
        /// Get the cumulative distribution functions of the pixels
        /// luminance distribution.
        /// </summary>
        decimal[] GetCDF(Bitmap bitmap);

        /// <summary>
        /// Get entropy of the pixels luminanance distribution.
        /// </summary>
        decimal GetEntropy(Bitmap bitmap);

        /// <summary>
        /// Get the probability mass function of the
        /// pixels luminance distribution.
        /// </summary>
        decimal[] GetPMF(Bitmap bitmap);

        /// <summary>
        /// Get the standard deviation
        /// of the pixels luminance distribution.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        decimal GetStandardDeviation(Bitmap bitmap);

        /// <summary>
        /// Get the conditional expected value
        /// of the pixels luminance distribution.
        /// </summary>
        decimal GetConditionalExpectation((int x1, int x2) interval, Bitmap bitmap);

        /// <summary>
        /// Get conditional variance 
        /// of the pixels luminance distribution.
        /// </summary>
        decimal GetConditionalVariance((int x1, int x2) interval, Bitmap bitmap);
    }
}
