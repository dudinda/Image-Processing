using System.Drawing;

using ImageProcessing.App.ServiceLayer.Code.Enums;

namespace ImageProcessing.App.ServiceLayer.Providers.Visitors.Convolution
{
    public interface IConvolutionVisitor
    {
        Bitmap LoGOperator3x3(Bitmap bmp);
        Bitmap SobelOverator3x3(Bitmap bmp);
        Bitmap Operator(Bitmap bmp, ConvKernel filter);
    }
}
