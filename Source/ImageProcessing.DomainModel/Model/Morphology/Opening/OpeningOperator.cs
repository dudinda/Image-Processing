using System.Drawing;

using ImageProcessing.Common.Helpers;
using ImageProcessing.Common.Utility.BitMatrix.Implementation;
using ImageProcessing.Core.Model.Morphology.UnaryOperator;

namespace ImageProcessing.DomainModel.Model.Morphology.Opening
{
    /// <summary>
    /// Implements the <see cref="IMorphologyUnary"/>.
    /// </summary>
    public class OpeningOperator : IMorphologyUnary
    {
        /// <inheritdoc />
        public Bitmap Filter(Bitmap bitmap, BitMatrix kernel)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));
            Requires.IsNotNull(kernel, nameof(kernel));

            var dilation = new DilationOperator();
            var erosion  = new ErosionOperator();

            return dilation.Filter(erosion.Filter(bitmap, kernel), kernel);
        }
    }
}
