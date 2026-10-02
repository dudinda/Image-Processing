using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Rgb.Interface;
using ImageProcessing.App.Domain.Models.Rgb;
using ImageProcessing.App.Domain.Services.Factories.Rgb;

namespace ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Rgb.Implementation
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
