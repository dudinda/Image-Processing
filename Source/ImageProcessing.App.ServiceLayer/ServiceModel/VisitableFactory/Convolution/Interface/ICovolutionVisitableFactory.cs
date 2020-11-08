using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.Convolution;
using ImageProcessing.Microkernel.MVP.Model;

namespace ImageProcessing.App.ServiceLayer.ServiceModel.VisitableFactory.Convolution.Interface
{
    internal interface ICovolutionVisitableFactory : IModelFactory<IConvolutionVisitable, ConvKernel>
    {

    }
}
