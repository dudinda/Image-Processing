using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.ServiceLayer.Visitors.Convolution.Visitable;
using ImageProcessing.Microkernel.MVP.Model;

namespace ImageProcessing.App.ServiceLayer.CompoundModels.VisitableFactory.Convolution.Interface
{
    internal interface ICovolutionVisitableFactory : IModelFactory<IConvolutionVisitable, ConvolutionFilter>
    {

    }
}
