using System.Drawing;

using ImageProcessing.Common.Helpers;
using ImageProcessing.Common.Utility.BitMatrix.Implementation;
using ImageProcessing.DomainModel.Model.Morphology.Interface.BinaryOperator;
using ImageProcessing.DomainModel.Model.Morphology.Interface.UnaryOperator;
using ImageProcessing.ServiceLayer.Services.Morphology.Interface;

namespace ImageProcessing.ServiceLayer.Services.Morphology.Implementation
{
    public sealed class MorphologyService : IMorphologyService
    {
        public Bitmap ApplyOperator(Bitmap bmp, BitMatrix kernel, IMorphologyUnary filter)
        {
            Requires.IsNotNull(bmp, nameof(bmp));
            Requires.IsNotNull(filter, nameof(filter));

            return filter.Filter(bmp, kernel);
        }
        
        public Bitmap ApplyOperator(Bitmap lvalue, Bitmap rvalue, IMorphologyBinary filter)
        {
            Requires.IsNotNull(rvalue, nameof(rvalue));
            Requires.IsNotNull(lvalue, nameof(lvalue));
            Requires.IsNotNull(filter, nameof(filter));

            return filter.Filter(rvalue, lvalue);
        }
    }
}
