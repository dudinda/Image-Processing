using System.Drawing;

using ImageProcessing.Common.Utility.BitMatrix.Implementation;
using ImageProcessing.DomainModel.Model.Morphology.Interface.BinaryOperator;
using ImageProcessing.DomainModel.Model.Morphology.Interface.UnaryOperator;

namespace ImageProcessing.ServiceLayer.Services.Morphology.Interface
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
