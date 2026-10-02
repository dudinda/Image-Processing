using System.Drawing;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.Utility.DataStructure.BitMatrixSrc.Implementation;

namespace ImageProcessing.App.ServiceLayer.Models.Morphology
{
    /// <summary>
    /// Specifies the unary morphology operator.
    /// </summary>
    public interface IMorphologyUnary 
    {
        /// <summary>
        /// Transform the specifed bitmap by the <see cref="StructElem"/> operation,
        /// with the specified <see cref="BitMatrix"/> kernel.
        /// </summary>
        Bitmap Filter(Bitmap bitmap, BitMatrix kernel);
    }
}
