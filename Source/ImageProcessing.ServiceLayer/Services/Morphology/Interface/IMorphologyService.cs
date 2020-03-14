using System.Drawing;

using ImageProcessing.Common.Utility.BitMatrix.Implementation;
using ImageProcessing.DomainModel.Model.Morphology.Interface.BinaryOperator;
using ImageProcessing.DomainModel.Model.Morphology.Interface.UnaryOperator;

namespace ImageProcessing.ServiceLayer.Services.Morphology.Interface
{
    public interface IMorphologyService
    {
        Bitmap ApplyOperator(Bitmap bmp, BitMatrix kernel, IMorphologyUnary filter);
        Bitmap ApplyOperator(Bitmap lvalue, Bitmap rvalue, IMorphologyBinary filter);
    }
}
