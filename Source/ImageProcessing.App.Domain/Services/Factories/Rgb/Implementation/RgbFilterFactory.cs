using System;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Models.Options;
using ImageProcessing.App.Domain.Models.Rgb;
using ImageProcessing.App.Domain.Models.Rgb.RgbFilter.Implementation;
using ImageProcessing.App.Domain.Services.Factories.Recommendation;

namespace ImageProcessing.App.Domain.Services.Factories.Rgb.Implementation
{

    /// <inheritdoc cref="IRgbFilterFactory"/>
    public sealed class RgbFilterFactory : IRgbFilterFactory
    {
        private readonly IChannelFactory _factory;
        private readonly IRecommendationFactory _rec;
        private readonly AppOptions _settings;

        public RgbFilterFactory(
            IRecommendationFactory rec,
            IChannelFactory factory,
            AppOptions settings)
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
