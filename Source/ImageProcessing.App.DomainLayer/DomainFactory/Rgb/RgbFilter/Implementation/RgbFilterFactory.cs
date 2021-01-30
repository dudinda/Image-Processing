using System;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.Channel.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.RgbFilter.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.RgbFilters.Recommendation.Interface;
using ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Implementation;
using ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Interface;
using ImageProcessing.App.ServiceLayer.Services.Settings.Interface;

namespace ImageProcessing.App.DomainLayer.DomainFactory.Rgb.RgbFilter.Implementation
{

    /// <inheritdoc cref="IRgbFilterFactory"/>
    public sealed class RgbFilterFactory : IRgbFilterFactory
    {
        private readonly IChannelFactory _factory;
        private readonly IRecommendationFactory _rec;
        private readonly IAppSettings _settings;

        public RgbFilterFactory(
            IRecommendationFactory rec,
            IChannelFactory factory,
            IAppSettings settings)
        {
            _rec = rec;
            _factory = factory;
            _settings = settings;
        }

        /// <summary>
        /// Provides a factory method for all the <see cref="RgbFltr"/>
        /// implementing the <see cref="IRgbFilter"/>.
        /// </summary>
        public IRgbFilter Get(RgbFltr filter)
        {
            var rec = _rec.Get(_settings.Rec);

            return filter switch
            {
                RgbFltr.Binary
                    => new BinaryFilter(rec),
                RgbFltr.Grayscale
                    => new GrayscaleFilter(rec),
                RgbFltr.Inversion
                    => new InversionFilter(),
                RgbFltr.Flopping
                    => new FloppingFilter(),
                RgbFltr.Flipping
                    => new FlippingFilter(),
                RgbFltr.SepiaTone
                    => new SepiaToneFilter(),

                _   => throw new NotImplementedException(nameof(filter))
            };
        }
           
          
        /// <inheritdoc />
		public IRgbFilter Get(RgbChannels channel)
            => new ChannelFilter(_factory.Get(channel));     
    }
}
