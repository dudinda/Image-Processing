using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.ServiceLayer.Providers.Interface.BitmapDistribution
{
    /// <summary>
    /// Provides the <see cref="Distribution"/> and
    /// <see cref="RandomVariableInfo"/> implementation for a bitmap.
    /// </summary>
    public interface IBitmapLuminanceDistributionServiceProvider
    {
        /// <summary>
        /// Transfrom the specified bitmap to a <see cref="Distribution"/> with
        /// <see cref="parms"/>.
        /// </summary>
        Bitmap Transform(Bitmap bmp, Distribution distribution, (string, string) parms);

        /// <summary>
        /// Get the information about a <see cref="Bitmap"/> luminance distribution.
        /// </summary>
        decimal GetInfo(Bitmap bmp, RandomVariableInfo info);
    }
}
