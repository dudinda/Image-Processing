using System.Drawing;

using ImageProcessing.App.Domain.Code.Collections;
using ImageProcessing.App.Domain.Code.Enums;

namespace ImageProcessing.App.Domain.Models.Morphology
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
