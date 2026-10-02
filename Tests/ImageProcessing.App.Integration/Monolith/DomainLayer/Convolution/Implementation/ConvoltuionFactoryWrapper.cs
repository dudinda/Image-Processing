using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Convolution.Interface;
using ImageProcessing.App.ServiceLayer.Models.Convolution;
using ImageProcessing.App.ServiceLayer.Services.Factories.Convolution;

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
