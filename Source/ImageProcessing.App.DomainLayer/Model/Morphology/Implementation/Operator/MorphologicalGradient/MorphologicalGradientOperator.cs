using System.Drawing;

using ImageProcessing.App.CommonLayer.Helpers;
using ImageProcessing.App.DomainLayer.Model.Morphology.Implementation.Dilation;
using ImageProcessing.App.DomainLayer.Model.Morphology.Implementation.Erosion;
using ImageProcessing.App.DomainLayer.Model.Morphology.Implementation.Subtraction;
using ImageProcessing.App.DomainLayer.Model.Morphology.Interface.UnaryOperator;
using ImageProcessing.Utility.DataStructure.BitMatrix.Implementation;

namespace ImageProcessing.App.DomainLayer.Model.Morphology.Implementation.MorphologicalGradient
{
    /// <summary>
    /// Implements the <see cref="IMorphologyUnary"/>.
    /// </summary>
    internal sealed class MorphologicalGradientOperator : IMorphologyUnary
    {
        /// <inheritdoc />
        public Bitmap Filter(Bitmap bitmap, BitMatrix kernel)
        {
            Requires.IsNotNull(bitmap, nameof(bitmap));
            Requires.IsNotNull(kernel, nameof(kernel));

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
