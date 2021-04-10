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
    internal sealed class OpeningOperator : IMorphologyUnary
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

            var dilation = new DilationOperator();
            var erosion = new ErosionOperator();

            return dilation.Filter(erosion.Filter(bitmap, kernel), kernel);
        }
    }
}
