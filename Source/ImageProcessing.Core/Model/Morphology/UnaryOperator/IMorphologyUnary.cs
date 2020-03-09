using System.Drawing;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Utility.BitMatrix.Implementation;
using ImageProcessing.Core.Model.Morphology.Base;

namespace ImageProcessing.Core.Model.Morphology.UnaryOperator
{
    /// <summary>
    /// Specifies the unary morphology operator.
    /// Marked by <see cref="IMorphologyBase"/>.
    /// </summary>
    public interface IMorphologyUnary : IMorphologyBase
    {
        /// <summary>
        /// Transform the specifed bitmap by the <see cref="MorphologyShape"/> operation,
        /// with the specified <see cref="BitMatrix"/> kernel.
        /// </summary>
        Bitmap Filter(Bitmap bitmap, BitMatrix kernel);
    }
}
