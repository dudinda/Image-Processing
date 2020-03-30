using System.Drawing;

using ImageProcessing.Common.Enums;

namespace ImageProcessing.DomainModel.Model.Morphology.Interface.BinaryOperator
{
    /// <summary>
    /// Specifies a binary morphology operator.
    /// </summary>
    public interface IMorphologyBinary 
    {
        /// <summary>
        /// Get the result of a <see cref="MorphologyOperator.Addition" /> opertaion
        /// or <see cref="MorphologyOperator.Subtraction"/>. 
        /// </summary>
        Bitmap Filter(Bitmap lvalue, Bitmap rvalue);
    }
}
