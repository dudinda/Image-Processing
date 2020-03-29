using System.Drawing;

using ImageProcessing.Common.Helpers;
using ImageProcessing.Common.Utility.BitMatrix.Implementation;
using ImageProcessing.DomainModel.Model.Morphology.Implementation.Dilation;
using ImageProcessing.DomainModel.Model.Morphology.Implementation.Erosion;
using ImageProcessing.DomainModel.Model.Morphology.Interface.UnaryOperator;

namespace ImageProcessing.DomainModel.Model.Morphology.Implementation.Opening
{
    /// <summary>
    /// Implements the <see cref="IMorphologyUnary"/>.
    /// </summary>
    internal sealed class OpeningOperator : IMorphologyUnary
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
