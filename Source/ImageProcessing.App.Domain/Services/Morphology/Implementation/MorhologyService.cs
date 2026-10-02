using System.Drawing;

using ImageProcessing.App.Domain.Models.Morphology;
using ImageProcessing.Utility.DataStructure.BitMatrixSrc.Implementation;

namespace ImageProcessing.App.Domain.Services.Morphology.Implementation
{
    /// <inheritdoc  cref="IMorphologyService"/>
    public sealed class MorphologyService : IMorphologyService
    {
        /// <inheritdoc />
        public Bitmap ApplyOperator(Bitmap bmp, BitMatrix kernel, IMorphologyUnary filter)
            => filter.Filter(bmp, kernel);
        
        /// <inheritdoc />
        public Bitmap ApplyOperator(Bitmap lvalue, Bitmap rvalue, IMorphologyBinary filter)
            => filter.Filter(rvalue, lvalue);
    }
}
