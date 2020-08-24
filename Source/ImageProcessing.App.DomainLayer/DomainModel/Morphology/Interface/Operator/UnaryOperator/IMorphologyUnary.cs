using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.Utility.DataStructure.BitMatrixSrc.Implementation;

namespace ImageProcessing.App.DomainLayer.DomainModel.Morphology.Interface.UnaryOperator
{
    /// <summary>
    /// Specifies the unary morphology operator.
    /// </summary>
    public interface IMorphologyUnary 
    {
        /// <summary>
        /// Transform the specifed bitmap by the <see cref="StructuringElem"/> operation,
        /// with the specified <see cref="BitMatrix"/> kernel.
        /// </summary>
        Bitmap Filter(Bitmap bitmap, BitMatrix kernel);
    }
}