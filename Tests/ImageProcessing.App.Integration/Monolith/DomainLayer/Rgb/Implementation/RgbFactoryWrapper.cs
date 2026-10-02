using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Rgb.Interface;
using ImageProcessing.App.ServiceLayer.Models.Rgb;
using ImageProcessing.App.ServiceLayer.Services.Factories.Rgb;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Rgb.Implementation
{
    internal class RgbFactoryWrapper : IRgbFactoryWrapper
    {
        private readonly IRgbFilterFactory _factory;

        public RgbFactoryWrapper(IRgbFilterFactory factory)
        {
            _factory = factory;
        }

        public virtual IRgbFilter Get(RgbChannels channel)
            => _factory.Get(channel);

        public virtual IRgbFilter Get(RgbFltr model)
            => _factory.Get(model);
    }
}
