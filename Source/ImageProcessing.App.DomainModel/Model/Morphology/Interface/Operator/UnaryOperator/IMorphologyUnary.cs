using System.Drawing;

using ImageProcessing.App.Common.Enums;
using ImageProcessing.Utility.DataStructure.BitMatrix.Implementation;

namespace ImageProcessing.App.DomainModel.Model.Morphology.Interface.UnaryOperator
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
