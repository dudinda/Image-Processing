using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Factories;
using ImageProcessing.App.ServiceLayer.Providers.Visitable.Convolution;

namespace ImageProcessing.App.ServiceLayer.Providers.VisitableFactory.Convolution
{
    public interface ICovolutionVisitableFactory : IModelFactory<IConvolutionVisitable, ConvKernel>
    {

    }
}
