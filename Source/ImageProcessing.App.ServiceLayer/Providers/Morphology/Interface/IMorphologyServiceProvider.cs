using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.Utility.DataStructure.BitMatrixSrc.Implementation;

namespace ImageProcessing.App.ServiceLayer.Providers.Interface.Morphology
{
    /// <summary>
    /// Provides the <see cref="MorphologyOperator"/> implementation.
    /// </summary>
    public interface IMorphologyServiceProvider
    {
        /// <summary>
        /// Apply an unary <see cref="MorphologyOperator"/> with
        /// the specified <see cref="StructuringElem"/> with a dimension of
        /// width x height.
        /// </summary>
        Bitmap ApplyUnary(Bitmap bmp, StructuringElem kernel, (int width, int height) dim, MorphologyOperator filter);

        /// Apply an unary <see cref="MorphologyOperator"/> with a custom <see cref="BitMatrix"/> kernel.
        Bitmap ApplyCustomUnary(Bitmap bmp, BitMatrix kernel, MorphologyOperator filter);

        /// <summary>
        /// Apply a binary <see cref="MorphologyOperator"/>.
        /// </summary>
        Bitmap ApplyBinary(Bitmap lvalue, Bitmap rvalue, MorphologyOperator filter);
    }
}
