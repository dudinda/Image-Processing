using System;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Models.Rgb.RgbFilter.Implementation;
using ImageProcessing.App.ServiceLayer.Models.AppSettings;
using ImageProcessing.App.ServiceLayer.Models.Rgb;
using ImageProcessing.App.ServiceLayer.Services.Factories.Recommendation;
using ImageProcessing.App.ServiceLayer.Services.Factories.Rgb;

namespace ImageProcessing.App.ServiceLayer.Services.Factories.Rgb.Implementation
{

    /// <inheritdoc cref="IRgbFilterFactory"/>
    public sealed class RgbFilterFactory : IRgbFilterFactory
    {
        private readonly IChannelFactory _factory;
        private readonly IRecommendationFactory _rec;
        private readonly AppSettings _settings;

        public RgbFilterFactory(
            IRecommendationFactory rec,
            IChannelFactory factory,
            AppSettings settings)
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
                RgbFltr.MirrorLeft
                    => new MirrorLeftFilter(),
                RgbFltr.MirrorRight
                    => new MirrorRightFilter(),

                _   => throw new NotImplementedException(nameof(filter))
            };
        }
           
          
        /// <inheritdoc />
		public IRgbFilter Get(RgbChannels channel)
            => new ChannelFilter(_factory.Get(channel));     
    }
}
