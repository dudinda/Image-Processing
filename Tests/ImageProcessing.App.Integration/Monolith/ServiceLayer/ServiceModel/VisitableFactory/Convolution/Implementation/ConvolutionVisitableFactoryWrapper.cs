using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Integration.Monolith.Domain.ServiceModel.VisitableFactory.Convolution.Interface;
using ImageProcessing.App.Domain.Providers.Visitable.Convolution;
using ImageProcessing.App.Domain.Providers.VisitableFactory.Convolution.Implementation;

namespace ImageProcessing.App.Integration.Monolith.Domain.ServiceModel.VisitableFactory.Convolution.Implementation
{
    internal class ConvolutionVisitableFactoryWrapper : IConvolutionVisitableFactoryWrapper
    {
        private readonly ConvolutionVisitableFactory _factory
            = new ConvolutionVisitableFactory();

        public virtual IConvolutionVisitable Get(ConvKernel model)
            => _factory.Get(model);
    }
}
