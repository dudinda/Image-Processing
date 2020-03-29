using System.Drawing;

using ImageProcessing.Common.Helpers;
using ImageProcessing.Common.Utility.BitMatrix.Implementation;
using ImageProcessing.DomainModel.Model.Morphology.Implementation.Opening;
using ImageProcessing.DomainModel.Model.Morphology.Implementation.Subtraction;
using ImageProcessing.DomainModel.Model.Morphology.Interface.UnaryOperator;

namespace ImageProcessing.DomainModel.Model.Morphology.Implementation.TopHat
{
    /// <summary>
    /// Implements the <see cref="IMorphologyUnary"/>.
    /// </summary>
    internal sealed class TopHatOperator : IMorphologyUnary
    {
        /// <inheritdoc />
        public Bitmap Filter(Bitmap bitmap, BitMatrix kernel)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));
            Requires.IsNotNull(kernel, nameof(kernel));

            var opening     = new OpeningOperator();
            var subtraction = new SubtractionOperator();

            using (var lvalue = new Bitmap(bitmap))
            {
                return subtraction.Filter(lvalue, opening.Filter(bitmap, kernel));
            }
        }
    }
}
