using System.Drawing;

using ImageProcessing.App.Domain.Models.Morphology;
using ImageProcessing.Utility.DataStructure.BitMatrixSrc.Implementation;

namespace ImageProcessing.App.Domain.Services.Morphology
{
    /// <summary>
    /// Provides the morphology operators with
    /// the different arity.
    /// </summary>
    public interface IMorphologyService
    {
        /// <summary>
        /// Perform a unary morphological filter
        /// on the specified bitmap. Can accept a custom
        /// kernel.
        /// </summary>
        Bitmap ApplyOperator(Bitmap bmp, BitMatrix kernel, IMorphologyUnary filter);

        /// <summary>
        /// Perform a binary morphological filter
        /// on the specified bitmap.
        Bitmap ApplyOperator(Bitmap lvalue, Bitmap rvalue, IMorphologyBinary filter);
    }
}
