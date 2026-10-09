using System.Drawing;

using ImageProcessing.App.Domain.Code.Enums;

namespace ImageProcessing.App.Domain.Providers.BitmapLuminance
{
    /// <summary>
    /// Provides the <see cref="PrDistribution"/> and
    /// <see cref="RndInfo"/> implementation for a bitmap.
    /// </summary>
    public interface IBitmapLuminanceProvider
    {
        /// <summary>
        /// Transfrom the specified bitmap to a <see cref="PrDistribution"/> with
        /// <see cref="parms"/>.
        /// </summary>
        Bitmap Transform(Bitmap bmp, PrDistribution distribution, (string, string) parms);

        /// <summary>
        /// Get the information about a <see cref="Bitmap"/> luminance distribution.
        /// </summary>
        decimal GetInfo(Bitmap bmp, RndInfo info);
    }
}
