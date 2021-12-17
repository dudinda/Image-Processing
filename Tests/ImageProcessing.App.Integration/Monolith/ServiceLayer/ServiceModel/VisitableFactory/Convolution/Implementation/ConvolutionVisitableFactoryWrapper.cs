using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.ServiceModel.VisitableFactory.Convolution.Interface;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.Convolution;
using ImageProcessing.App.ServiceLayer.ServiceModel.VisitableFactory.Convolution.Implementation;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.ServiceModel.VisitableFactory.Convolution.Implementation
{
    internal class ConvolutionVisitableFactoryWrapper : IConvolutionVisitableFactoryWrapper
    {
        private readonly ConvolutionVisitableFactory _factory
            = new ConvolutionVisitableFactory();

        public virtual IConvolutionVisitable Get(ConvKernel model)
            => _factory.Get(model);
    }
}
