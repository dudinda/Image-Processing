using System.Drawing;

using ImageProcessing.App.DomainLayer.Model.Morphology.Implementation.Opening;
using ImageProcessing.App.DomainLayer.Model.Morphology.Implementation.Subtraction;
using ImageProcessing.App.DomainLayer.Model.Morphology.Interface.UnaryOperator;
using ImageProcessing.Utility.DataStructure.BitMatrixSrc.Implementation;

namespace ImageProcessing.App.DomainLayer.Model.Morphology.Implementation.TopHat
{
    /// <summary>
    /// Implements the <see cref="IMorphologyUnary"/>.
    /// </summary>
    internal sealed class TopHatOperator : IMorphologyUnary
    {
        /// <inheritdoc />
        public Bitmap Filter(Bitmap bitmap, BitMatrix kernel)
        {
            var opening     = new OpeningOperator();
            var subtraction = new SubtractionOperator();

            using (var lvalue = new Bitmap(bitmap))
            {
                return subtraction.Filter(lvalue, opening.Filter(bitmap, kernel));
            }
        }
    }
}
