using System.Drawing;

using ImageProcessing.App.ServiceLayer.Providers.Visitable;
using ImageProcessing.App.ServiceLayer.Providers.Visitors.Convolution;

namespace ImageProcessing.App.ServiceLayer.Providers.Visitable.Convolution
{
    public interface IConvolutionVisitable
        : IVisitable<IConvolutionVisitable, IConvolutionVisitor>
    {
        Bitmap Filter(Bitmap bmp);
    }
}
