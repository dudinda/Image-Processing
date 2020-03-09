using System.Drawing;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Model.Morphology.Base;

namespace ImageProcessing.Core.Model.Morphology.BinaryOperator
{
    /// <summary>
    /// Specifies the binary morphology operator.
    /// Marked by <see cref="IMorphologyBase"/>.
    /// </summary>
    public interface IMorphologyBinary : IMorphologyBase
    {
        /// <summary>
        /// Get the result of <see cref="MorphologyOperator.Addition" /> or <see cref="MorphologyOperator.Subtraction"/>. 
        /// </summary>
        Bitmap Filter(Bitmap lvalue, Bitmap rvalue);
    }
}
