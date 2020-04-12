using System.Drawing;

using ImageProcessing.App.Common.Helpers;
using ImageProcessing.App.Common.Utility.BitMatrix.Implementation;
using ImageProcessing.App.DomainModel.Model.Morphology.Implementation.Dilation;
using ImageProcessing.App.DomainModel.Model.Morphology.Implementation.Erosion;
using ImageProcessing.App.DomainModel.Model.Morphology.Interface.UnaryOperator;

namespace ImageProcessing.App.DomainModel.Model.Morphology.Implementation.Opening
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
