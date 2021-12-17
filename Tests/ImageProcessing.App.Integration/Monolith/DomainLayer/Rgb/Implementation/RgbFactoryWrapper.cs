using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.RgbFilter.Interface;
using ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Rgb.Interface;

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
