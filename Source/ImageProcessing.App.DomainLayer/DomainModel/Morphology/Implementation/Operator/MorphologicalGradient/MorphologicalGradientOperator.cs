using System.Drawing;

using ImageProcessing.App.DomainLayer.DomainModel.Morphology.Implementation.Dilation;
using ImageProcessing.App.DomainLayer.DomainModel.Morphology.Implementation.Erosion;
using ImageProcessing.App.DomainLayer.DomainModel.Morphology.Implementation.Subtraction;
using ImageProcessing.App.DomainLayer.DomainModel.Morphology.Interface.UnaryOperator;
using ImageProcessing.Utility.DataStructure.BitMatrixSrc.Implementation;

namespace ImageProcessing.App.DomainLayer.DomainModel.Morphology.Implementation.MorphologicalGradient
{
    /// <summary>
    /// Implements the <see cref="IMorphologyUnary"/>.
    /// </summary>
    internal sealed class MorphologicalGradientOperator : IMorphologyUnary
    {
        /// <inheritdoc />
        public Bitmap Filter(Bitmap bitmap, BitMatrix kernel)
        {
            var subtraction = new SubtractionOperator();
            var dilation    = new DilationOperator();
            var erosion     = new ErosionOperator();

            using (var rvalue = new Bitmap(bitmap))
            {
                return subtraction
                    .Filter(dilation.Filter(bitmap, kernel),
                            erosion.Filter(rvalue, kernel)
                );
            }
        }
    }
}
