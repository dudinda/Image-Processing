using System.Drawing;

using ImageProcessing.App.DomainLayer.Code.Extensions.BitmapExt;
using ImageProcessing.App.DomainLayer.DomainModel.Morphology.Interface.UnaryOperator;
using ImageProcessing.Utility.DataStructure.BitMatrixSrc.Implementation;

namespace ImageProcessing.App.DomainLayer.DomainModel.Morphology.Implementation.Operator
{
    /// <summary>
    /// Implements the <see cref="IMorphologyUnary"/>.
    /// </summary>
    internal sealed class TopHatOperator : IMorphologyUnary
    {
        /// <inheritdoc />
        public Bitmap Filter(Bitmap bitmap, BitMatrix kernel)
        {
            bitmap.IsSupported();

            var opening     = new OpeningOperator();
            var subtraction = new SubtractionOperator();

            using (var lvalue = new Bitmap(bitmap))
            {
                return subtraction.Filter(lvalue, opening.Filter(bitmap, kernel));
            }
        }
    }
}
