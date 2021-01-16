using System.Drawing;

using ImageProcessing.App.ServiceLayer.ServiceModel.Visitors.Convolution.Interface;

namespace ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.Convolution
{
    public interface IConvolutionVisitable
        : IVisitable<IConvolutionVisitable, IConvolutionVisitor>
    {
        Bitmap Filter(Bitmap bmp);
    }
}
