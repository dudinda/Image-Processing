using System.Drawing;

using ImageProcessing.Common.Helpers;
using ImageProcessing.Common.Utility.BitMatrix.Implementation;
using ImageProcessing.Core.Model.Morphology.UnaryOperator;
using ImageProcessing.DomainModel.Model.Morphology.Opening;
using ImageProcessing.DomainModel.Model.Morphology.Subtraction;

namespace ImageProcessing.DomainModel.Model.Morphology.TopHat
{
    /// <summary>
    /// Implements the <see cref="IMorphologyUnary"/>.
    /// </summary>
    public class TopHatOperator : IMorphologyUnary
    {
        /// <inheritdoc />
        public Bitmap Filter(Bitmap bitmap, BitMatrix kernel)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));
            Requires.IsNotNull(kernel, nameof(kernel));

            var opening     = new OpeningOperator();
            var subtraction = new SubtractionOperator();

            return subtraction.Filter(bitmap, opening.Filter(bitmap, kernel));
        }
    }
}
