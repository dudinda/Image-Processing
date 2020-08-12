using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.ServiceLayer.Providers.Interface.BitmapDistribution
{
    /// <summary>
    /// Provides the <see cref="Distributions"/> and
    /// <see cref="RandomVariableInfo"/> implementation for a bitmap.
    /// </summary>
    public interface IBitmapLuminanceServiceProvider
    {
        /// <summary>
        /// Transfrom the specified bitmap to a <see cref="Distributions"/> with
        /// <see cref="parms"/>.
        /// </summary>
        Bitmap Transform(Bitmap bmp, Distributions distribution, (string, string) parms);

        /// <summary>
        /// Get the information about a <see cref="Bitmap"/> luminance distribution.
        /// </summary>
        decimal GetInfo(Bitmap bmp, RandomVariableInfo info);
    }
}
