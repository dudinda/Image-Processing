using System.Drawing;

using ImageProcessing.Common.Helpers;
using ImageProcessing.Common.Utility.BitMatrix.Implementation;
using ImageProcessing.Core.Model.Morphology.UnaryOperator;
using ImageProcessing.DomainModel.Model.Morphology.Closing;
using ImageProcessing.DomainModel.Model.Morphology.Subtraction;

namespace ImageProcessing.DomainModel.Model.Morphology.BlackHat
{
    /// <summary>
    /// Implements the <see cref="IMorphologyUnary"/>.
    /// </summary>
    public class BlackHatOperator : IMorphologyUnary
    {
        /// <inheritdoc />
        public Bitmap Filter(Bitmap bitmap, BitMatrix kernel)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));
            Requires.IsNotNull(kernel, nameof(kernel));

            var subtraction = new SubtractionOperator();
            var closing     = new ClosingOperator();

            return subtraction.Filter(closing.Filter(bitmap, kernel), bitmap);
        }
    }
}
