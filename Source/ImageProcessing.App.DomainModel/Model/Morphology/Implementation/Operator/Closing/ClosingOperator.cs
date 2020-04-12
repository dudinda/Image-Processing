using System.Drawing;

using ImageProcessing.App.Common.Helpers;
using ImageProcessing.App.DomainModel.Model.Morphology.Implementation.Dilation;
using ImageProcessing.App.DomainModel.Model.Morphology.Implementation.Erosion;
using ImageProcessing.App.DomainModel.Model.Morphology.Interface.UnaryOperator;
using ImageProcessing.Utility.DataStructure.BitMatrix.Implementation;

namespace ImageProcessing.App.DomainModel.Model.Morphology.Implementation.Closing
{
    /// <summary>
    /// Implements the <see cref="IMorphologyUnary"/>.
    /// </summary>
    internal sealed class ClosingOperator : IMorphologyUnary
    {
        /// <inheritdoc />
        public Bitmap Filter(Bitmap bitmap, BitMatrix kernel)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));
            Requires.IsNotNull(kernel, nameof(kernel));

            var dilation = new DilationOperator();
            var erosion  = new ErosionOperator();

            return erosion.Filter(dilation.Filter(bitmap, kernel), kernel);
        }
    }
}
