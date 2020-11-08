using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.ServiceLayer.ServiceModel.Visitors.Convolution.Interface
{
    internal interface IConvolutionVisitor
    {
        Bitmap LoGOperator3x3(Bitmap bmp);
        Bitmap SobelOverator3x3(Bitmap bmp);
        Bitmap Operator(Bitmap bmp, ConvKernel filter);
    }
}
