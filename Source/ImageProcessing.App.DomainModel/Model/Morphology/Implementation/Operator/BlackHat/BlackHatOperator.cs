using System.Drawing;

using ImageProcessing.App.Common.Helpers;
using ImageProcessing.App.Common.Utility.BitMatrix.Implementation;
using ImageProcessing.App.DomainModel.Model.Morphology.Implementation.Closing;
using ImageProcessing.App.DomainModel.Model.Morphology.Implementation.Subtraction;
using ImageProcessing.App.DomainModel.Model.Morphology.Interface.UnaryOperator;

namespace ImageProcessing.App.DomainModel.Model.Morphology.Implementation.BlackHat
{
    /// <summary>
    /// Implements the <see cref="IMorphologyUnary"/>.
    /// </summary>
    internal sealed class BlackHatOperator : IMorphologyUnary
    {
        /// <inheritdoc />
        public Bitmap Filter(Bitmap bitmap, BitMatrix kernel)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));
            Requires.IsNotNull(kernel, nameof(kernel));

            var subtraction = new SubtractionOperator();
            var closing     = new ClosingOperator();

            using (var rvalue = new Bitmap(bitmap))
            {    
                return subtraction.Filter(closing.Filter(bitmap, kernel), rvalue);
            }
        }
    }
}
