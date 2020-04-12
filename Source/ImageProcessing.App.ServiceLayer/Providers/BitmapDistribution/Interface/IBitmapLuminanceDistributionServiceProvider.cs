using System.Drawing;

using ImageProcessing.App.Common.Enums;

namespace ImageProcessing.App.ServiceLayer.Providers.Interface.BitmapDistribution
{
    public interface IBitmapLuminanceDistributionServiceProvider
    {
        /// <summary>
        /// Transfrom the specified bitmap to a <see cref="Distribution"/> with
        /// <see cref="parms"/>.
        /// </summary>
        /// <param name="bmp">The source bitmap.</param>
        /// <param name="distribution">A distribution.</param>
        /// <param name="parms">Distribution params.</param>
        /// <returns>Transformed to the specified distribution bitmap.</returns>
        Bitmap Transform(Bitmap bmp, Distribution distribution, (string, string) parms);

        /// <summary>
        /// Get the information about a <see cref="Bitmap"/> luminance distribution.
        /// </summary>
        decimal GetInfo(Bitmap bmp, RandomVariable info);
    }
}
