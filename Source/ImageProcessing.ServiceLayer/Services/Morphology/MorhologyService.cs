using System.Drawing;

using ImageProcessing.Common.Helpers;
using ImageProcessing.Common.Utility.BitMatrix.Implementation;
using ImageProcessing.Core.Model.Morphology.BinaryOperator;
using ImageProcessing.Core.Model.Morphology.UnaryOperator;
using ImageProcessing.Core.ServiceLayer.Services.Morphology;

namespace ImageProcessing.ServiceLayer.Services.Morphology
{
    public class MorphologyService : IMorphologyService
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
