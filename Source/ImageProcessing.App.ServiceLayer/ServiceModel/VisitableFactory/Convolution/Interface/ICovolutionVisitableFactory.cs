using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.Convolution;

namespace ImageProcessing.App.ServiceLayer.ServiceModel.VisitableFactory.Convolution.Interface
{
    public interface ICovolutionVisitableFactory : IModelFactory<IConvolutionVisitable, ConvKernel>
    {

    }
}
