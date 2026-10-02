using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Factories;
using ImageProcessing.App.Domain.Providers.Visitable.Convolution;

namespace ImageProcessing.App.Domain.Providers.VisitableFactory.Convolution
{
    public interface ICovolutionVisitableFactory : IModelFactory<IConvolutionVisitable, ConvKernel>
    {

    }
}
