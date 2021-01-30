using System.Drawing;

using ImageProcessing.App.DomainLayer.Code.Enums;

namespace ImageProcessing.App.ServiceLayer.ServiceModel.Visitors.Convolution.Interface
{
    public interface IConvolutionVisitor
    {
        Bitmap LoGOperator3x3(Bitmap bmp);
        Bitmap SobelOverator3x3(Bitmap bmp);
        Bitmap Operator(Bitmap bmp, ConvKernel filter);
    }
}
