using System;
using System.Drawing;
using System.Drawing.Imaging;

using ImageProcessing.App.DomainLayer.Code.Constants;
using ImageProcessing.App.DomainLayer.DomainModel.Morphology.Interface.UnaryOperator;
using ImageProcessing.Utility.DataStructure.BitMatrixSrc.Implementation;

namespace ImageProcessing.App.DomainLayer.DomainModel.Morphology.Implementation.Operator
{
    /// <summary>
    /// Implements the <see cref="IMorphologyUnary"/>.
    /// </summary>
    internal sealed class MorphologicalGradientOperator : IMorphologyUnary
    {
        /// <inheritdoc />
        public Bitmap Filter(Bitmap bitmap, BitMatrix kernel)
        {
            if (bitmap is null) { throw new ArgumentNullException(nameof(bitmap)); }
            if (kernel is null) { throw new ArgumentNullException(nameof(kernel)); }
            if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
            {
                throw new NotSupportedException(Errors.NotSupported);
            }

            var subtraction = new SubtractionOperator();
            var dilation = new DilationOperator();
            var erosion = new ErosionOperator();

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
