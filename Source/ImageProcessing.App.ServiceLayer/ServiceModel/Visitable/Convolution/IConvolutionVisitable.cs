using System.Drawing;

using ImageProcessing.App.ServiceLayer.CompoundModels.Visitable;
using ImageProcessing.App.ServiceLayer.CompoundModels.Visitors.Convolution.Interface;

namespace ImageProcessing.App.ServiceLayer.Visitors.Convolution.Visitable
{
    internal interface IConvolutionVisitable
        : IVisitable<IConvolutionVisitable, IConvolutionVisitor>
    {
        Bitmap Filter(Bitmap bmp);
    }
}
