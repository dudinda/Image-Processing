using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Factories.Rgb.RgbFilter.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Rgb.Interface;
using ImageProcessing.App.ServiceLayer.Models.Rgb;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Rgb.Implementation
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
