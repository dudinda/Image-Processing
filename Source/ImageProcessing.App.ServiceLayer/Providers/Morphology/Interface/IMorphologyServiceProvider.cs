using System.Drawing;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.Utility.DataStructure.BitMatrixSrc.Implementation;

namespace ImageProcessing.App.ServiceLayer.Providers.Interface.Morphology
{
    /// <summary>
    /// Provides the <see cref="MorphOperator"/> implementation.
    /// </summary>
    public interface IMorphologyServiceProvider
    {
        /// <summary>
        /// Apply an unary <see cref="MorphOperator"/> with
        /// the specified <see cref="StructElem"/> with a dimension of
        /// width x height.
        /// </summary>
        Bitmap ApplyUnary(Bitmap bmp, StructElem kernel, (int width, int height) dim, MorphOperator filter);

        /// Apply an unary <see cref="MorphOperator"/> with a custom <see cref="BitMatrix"/> kernel.
        Bitmap ApplyCustomUnary(Bitmap bmp, BitMatrix kernel, MorphOperator filter);

        /// <summary>
        /// Apply a binary <see cref="MorphOperator"/>.
        /// </summary>
        Bitmap ApplyBinary(Bitmap lvalue, Bitmap rvalue, MorphOperator filter);
    }
}
