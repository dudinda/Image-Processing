using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;

namespace ImageProcessing.App.ServiceLayer.CompoundModels.Visitors.Convolution.Interface
{
    internal interface IConvolutionVisitor
    {
        Bitmap LoGOperator3x3(Bitmap bmp);
        Bitmap SobelOverator3x3(Bitmap bmp);
        Bitmap Operator(Bitmap bmp, ConvolutionFilter filter);
    }
}
