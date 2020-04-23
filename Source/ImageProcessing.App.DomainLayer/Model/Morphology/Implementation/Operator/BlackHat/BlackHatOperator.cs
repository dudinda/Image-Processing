using System.Drawing;

using ImageProcessing.App.DomainLayer.Model.Morphology.Implementation.Closing;
using ImageProcessing.App.DomainLayer.Model.Morphology.Implementation.Subtraction;
using ImageProcessing.App.DomainLayer.Model.Morphology.Interface.UnaryOperator;
using ImageProcessing.Utility.DataStructure.BitMatrix.Implementation;

namespace ImageProcessing.App.DomainLayer.Model.Morphology.Implementation.BlackHat
{
    /// <summary>
    /// Implements the <see cref="IMorphologyUnary"/>.
    /// </summary>
    internal sealed class BlackHatOperator : IMorphologyUnary
    {
        /// <inheritdoc />
        public Bitmap Filter(Bitmap bitmap, BitMatrix kernel)
        {
            var subtraction = new SubtractionOperator();
            var closing     = new ClosingOperator();

            using (var rvalue = new Bitmap(bitmap))
            {    
                return subtraction.Filter(closing.Filter(bitmap, kernel), rvalue);
            }
        }
    }
}
