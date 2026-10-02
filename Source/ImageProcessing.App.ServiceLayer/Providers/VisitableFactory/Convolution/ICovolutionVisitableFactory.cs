using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Factories;
using ImageProcessing.App.ServiceLayer.Providers.Visitable.Convolution;

namespace ImageProcessing.App.ServiceLayer.Providers.VisitableFactory.Convolution
{
    public interface ICovolutionVisitableFactory : IModelFactory<IConvolutionVisitable, ConvKernel>
    {

    }
}
