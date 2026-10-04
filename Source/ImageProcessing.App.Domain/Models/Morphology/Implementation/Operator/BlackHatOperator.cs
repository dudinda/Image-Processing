using System;
using System.Drawing;
using System.Drawing.Imaging;

using ImageProcessing.App.Domain.Code.Collections;
using ImageProcessing.App.Domain.Code.Constants;

namespace ImageProcessing.App.Domain.Models.Morphology.Implementation.Operator
{
    /// <summary>
    /// Implements the <see cref="IMorphologyUnary"/>.
    /// </summary>
    internal sealed class BlackHatOperator : IMorphologyUnary
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
            var closing = new ClosingOperator();

            using (var rvalue = new Bitmap(bitmap))
            {
                return subtraction.Filter(closing.Filter(bitmap, kernel), rvalue);
            }
        }
    }
}
