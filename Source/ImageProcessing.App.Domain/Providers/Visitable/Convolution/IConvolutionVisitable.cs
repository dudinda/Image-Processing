using System.Drawing;

using ImageProcessing.App.Domain.Providers.Visitable;
using ImageProcessing.App.Domain.Providers.Visitors.Convolution;

namespace ImageProcessing.App.Domain.Providers.Visitable.Convolution
{
    public interface IConvolutionVisitable
        : IVisitable<IConvolutionVisitable, IConvolutionVisitor>
    {
        Bitmap Filter(Bitmap bmp);
    }
}
