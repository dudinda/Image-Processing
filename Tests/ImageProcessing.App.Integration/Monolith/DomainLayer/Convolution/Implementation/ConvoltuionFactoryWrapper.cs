using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.Convolution.Interface;
using ImageProcessing.App.DomainLayer.DomainModel.Convolution.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Convolution.Interface;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer
{
    internal class ConvoltuionFactoryWrapper : IConvolutionFactoryWrapper
    {
        private readonly IConvolutionFactory _factory;

        public ConvoltuionFactoryWrapper(IConvolutionFactory factory)
        {
            _factory = factory;
        }

        public virtual IConvolutionKernel Get(ConvKernel model)
            => _factory.Get(model);
    }
}
