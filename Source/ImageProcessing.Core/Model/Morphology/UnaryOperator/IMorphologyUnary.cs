using System.Drawing;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Utility.BitMatrix.Implementation;

namespace ImageProcessing.Core.Model.Morphology.UnaryOperator
{
    /// <summary>
    /// Specifies the unary morphology operator.
    /// </summary>
    public interface IMorphologyUnary 
    {
        /// <summary>
        /// Transform the specifed bitmap by the <see cref="MorphologyShape"/> operation,
        /// with the specified <see cref="BitMatrix"/> kernel.
        /// </summary>
        Bitmap Filter(Bitmap bitmap, BitMatrix kernel);
    }
}
