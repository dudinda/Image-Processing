using System.Drawing;

using ImageProcessing.App.Domain.Code.Collections;

namespace ImageProcessing.App.Domain.Services.ColorMatrix
{
    /// <summary>
    /// Use a <see cref="IColorMatrix"/>
    /// on the specified bitmap.
    /// </summary>
    public interface IColorMatrixService
    {
        /// <summary>
        /// Apply a color matrix to the specified bitmap.
        /// </summary>
        Bitmap Apply(Bitmap src, ReadOnly2DArray<double> mtx);
    }
}
