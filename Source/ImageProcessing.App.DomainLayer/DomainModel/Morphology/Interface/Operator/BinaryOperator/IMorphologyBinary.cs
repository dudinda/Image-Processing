using System.Drawing;

using ImageProcessing.App.DomainLayer.Code.Enums;

namespace ImageProcessing.App.DomainLayer.DomainModel.Morphology.Interface.BinaryOperator
{
    /// <summary>
    /// Specifies a binary morphology operator.
    /// </summary>
    public interface IMorphologyBinary 
    {
        /// <summary>
        /// Get the result of a <see cref="MorphOperator.Addition" /> opertaion
        /// or <see cref="MorphOperator.Subtraction"/>. 
        /// </summary>
        Bitmap Filter(Bitmap lvalue, Bitmap rvalue);
    }
}
