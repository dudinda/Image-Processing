using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Convolution.Interface;
using ImageProcessing.App.Domain.Models.Convolution;
using ImageProcessing.App.Domain.Services.Factories.Convolution;

namespace ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain
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
