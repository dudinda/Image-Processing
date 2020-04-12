using System.Drawing;

using ImageProcessing.App.Common.Helpers;
using ImageProcessing.App.Common.Utility.BitMatrix.Implementation;
using ImageProcessing.App.DomainModel.Model.Morphology.Implementation.Opening;
using ImageProcessing.App.DomainModel.Model.Morphology.Implementation.Subtraction;
using ImageProcessing.App.DomainModel.Model.Morphology.Interface.UnaryOperator;

namespace ImageProcessing.App.DomainModel.Model.Morphology.Implementation.TopHat
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
