using System.Drawing;

using ImageProcessing.Common.Enums;

namespace ImageProcessing.Core.Model.Morphology.BinaryOperator
{
    /// <summary>
    /// Specifies the binary morphology operator.
    /// </summary>
    public interface IMorphologyBinary 
    {
        /// <summary>
        /// Get the result of <see cref="MorphologyOperator.Addition" /> or <see cref="MorphologyOperator.Subtraction"/>. 
        /// </summary>
        Bitmap Filter(Bitmap lvalue, Bitmap rvalue);
    }
}
