using System.Drawing;

using ImageProcessing.Common.Helpers;
using ImageProcessing.Common.Utility.BitMatrix.Implementation;
using ImageProcessing.Core.Model.Morphology.UnaryOperator;
using ImageProcessing.DomainModel.Model.Morphology.Subtraction;

namespace ImageProcessing.DomainModel.Model.Morphology.MorphologicalGradient
{
    /// <summary>
    /// Implements the <see cref="IMorphologyUnary"/>.
    /// </summary>
    public class MorphologicalGradientOperator : IMorphologyUnary
    {
        /// <inheritdoc />
        public Bitmap Filter(Bitmap bitmap, BitMatrix kernel)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));
            Requires.IsNotNull(kernel, nameof(kernel));

            var subtraction = new SubtractionOperator();
            var dilation    = new DilationOperator();
            var erosion     = new ErosionOperator();

            return subtraction.Filter(dilation.Filter(bitmap, kernel), erosion.Filter(bitmap, kernel));
        }
    }
}
