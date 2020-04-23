using System.Drawing;

using ImageProcessing.App.DomainLayer.Model.Morphology.Implementation.Dilation;
using ImageProcessing.App.DomainLayer.Model.Morphology.Implementation.Erosion;
using ImageProcessing.App.DomainLayer.Model.Morphology.Interface.UnaryOperator;
using ImageProcessing.Utility.DataStructure.BitMatrix.Implementation;

namespace ImageProcessing.App.DomainLayer.Model.Morphology.Implementation.Opening
{
    /// <summary>
    /// Implements the <see cref="IMorphologyUnary"/>.
    /// </summary>
    internal sealed class OpeningOperator : IMorphologyUnary
    {
        /// <inheritdoc />
        public Bitmap Filter(Bitmap bitmap, BitMatrix kernel)
        {
            var dilation = new DilationOperator();
            var erosion  = new ErosionOperator();

            return dilation.Filter(erosion.Filter(bitmap, kernel), kernel);
        }
    }
}
