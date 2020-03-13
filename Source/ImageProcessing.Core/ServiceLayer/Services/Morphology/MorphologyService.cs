using System.Drawing;

using ImageProcessing.Common.Utility.BitMatrix.Implementation;
using ImageProcessing.Core.Model.Morphology.BinaryOperator;
using ImageProcessing.Core.Model.Morphology.UnaryOperator;

namespace ImageProcessing.Core.ServiceLayer.Services.Morphology
{
    public interface IMorphologyService
    {
        Bitmap ApplyOperator(Bitmap bmp, BitMatrix kernel, IMorphologyUnary filter);
        Bitmap ApplyOperator(Bitmap lvalue, Bitmap rvalue, IMorphologyBinary filter);
    }
}
