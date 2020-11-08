using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.Color.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.RgbFilter.Interface;
using ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Implementation;
using ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Interface;
using ImageProcessing.App.DomainLayer.Factory.RgbFilters.Recommendation.Interface;
using ImageProcessing.App.ServiceLayer.Services.Settings.Interface;

namespace ImageProcessing.App.DomainLayer.DomainFactory.Rgb.RgbFilter.Implementation
{

    /// <inheritdoc cref="IRgbFilterFactory"/>
    internal sealed class RgbFilterFactory : IRgbFilterFactory
    {
        private readonly IColorFactory _color;
        private readonly IRecommendationFactory _rec;
        private readonly IAppSettings _settings;

        public RgbFilterFactory(
            IRecommendationFactory rec,
            IColorFactory color,
            IAppSettings settings)
        {
            _rec = rec;
            _color = color;
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

                _ => throw new NotImplementedException(nameof(filter))
            };
        }
           
          
        /// <inheritdoc />
		public IRgbFilter Get(RgbColors color)
            => new ColorFilter(_color.Get(color));     
    }
}
