using System.Drawing;

using ImageProcessing.App.DomainLayer.DomainModel.Morphology.Implementation.Dilation;
using ImageProcessing.App.DomainLayer.DomainModel.Morphology.Implementation.Erosion;
using ImageProcessing.App.DomainLayer.DomainModel.Morphology.Interface.UnaryOperator;
using ImageProcessing.Utility.DataStructure.BitMatrixSrc.Implementation;

namespace ImageProcessing.App.DomainLayer.DomainModel.Morphology.Implementation.Closing
{
    /// <summary>
    /// Implements the <see cref="IMorphologyUnary"/>.
    /// </summary>
    internal sealed class ClosingOperator : IMorphologyUnary
    {
        /// <inheritdoc />
        public Bitmap Filter(Bitmap bitmap, BitMatrix kernel)
        {
            var dilation = new DilationOperator();
            var erosion  = new ErosionOperator();

            return erosion.Filter(dilation.Filter(bitmap, kernel), kernel);
        }
    }
}
