using System.Drawing;

using ImageProcessing.App.CommonLayer.Helpers;
using ImageProcessing.App.DomainLayer.Model.Morphology.Interface.BinaryOperator;
using ImageProcessing.App.DomainLayer.Model.Morphology.Interface.UnaryOperator;
using ImageProcessing.App.ServiceLayer.Services.Morphology.Interface;
using ImageProcessing.Utility.DataStructure.BitMatrix.Implementation;

namespace ImageProcessing.App.ServiceLayer.Services.Morphology.Implementation
{
    /// <inheritdoc  cref="IMorphologyService"/>
    public sealed class MorphologyService : IMorphologyService
    {
        /// <inheritdoc />
        public Bitmap ApplyOperator(Bitmap bmp, BitMatrix kernel, IMorphologyUnary filter)
        {
            Requires.IsNotNull(bmp, nameof(bmp));
            Requires.IsNotNull(filter, nameof(filter));

            return filter.Filter(bmp, kernel);
        }

        /// <inheritdoc />
        public Bitmap ApplyOperator(Bitmap lvalue, Bitmap rvalue, IMorphologyBinary filter)
        {
            Requires.IsNotNull(rvalue, nameof(rvalue));
            Requires.IsNotNull(lvalue, nameof(lvalue));
            Requires.IsNotNull(filter, nameof(filter));

            return filter.Filter(rvalue, lvalue);
        }
    }
}
