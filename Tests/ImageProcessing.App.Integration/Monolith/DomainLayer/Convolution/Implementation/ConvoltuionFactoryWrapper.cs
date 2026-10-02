using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Convolution.Interface;
using ImageProcessing.App.ServiceLayer.Models.Convolution;
using ImageProcessing.App.ServiceLayer.Services.Factories.Convolution;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer
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
