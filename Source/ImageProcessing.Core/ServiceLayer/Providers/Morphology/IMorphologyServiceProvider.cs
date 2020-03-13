using System.Drawing;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Utility.BitMatrix.Implementation;

namespace ImageProcessing.Core.ServiceLayer.Providers.Morphology
{
    public interface IMorphologyServiceProvider
    {
        Bitmap ApplyUnary(Bitmap bmp, BitMatrix kernel, MorphologyOperator filter);
        Bitmap ApplyBinary(Bitmap lvalue, Bitmap rvalue, MorphologyOperator filter);
    }
}
