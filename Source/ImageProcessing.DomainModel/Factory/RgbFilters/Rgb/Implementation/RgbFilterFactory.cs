using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Helpers;
using ImageProcessing.DomainModel.Factory.RgbFilters.Color.Interface;
using ImageProcessing.DomainModel.Factory.RgbFilters.Rgb.Interface;
using ImageProcessing.DomainModel.Model.RgbFilters.Implementation.Binary;
using ImageProcessing.DomainModel.Model.RgbFilters.Implementation.Color;
using ImageProcessing.DomainModel.Model.RgbFilters.Implementation.Grayscale;
using ImageProcessing.DomainModel.Model.RgbFilters.Implementation.Inversion;
using ImageProcessing.DomainModel.Model.RgbFilters.Interface;

namespace ImageProcessing.DomainModel.Factory.RgbFilters.Rgb.Implementation
{

    /// <inheritdoc cref="IRgbFilterFactory"/>
    public sealed class RgbFilterFactory : IRgbFilterFactory
    {
        private readonly IColorFactory _factory;

        public RgbFilterFactory(IColorFactory factory)
        {
            _factory = Requires.IsNotNull(
                factory, nameof(factory));
        }

        /// <summary>
        /// Provides a factory method for all <see cref="RgbFilter"/>
        /// implementing <see cref="IRgbFilter"/>.
        /// </summary>
        public IRgbFilter Get(RgbFilter filter)
        => filter switch
        {
            RgbFilter.Binary
                => new BinaryFilter(),
            RgbFilter.Grayscale
                => new GrayscaleFilter(),
            RgbFilter.Inversion
                => new InversionFilter(),

            _   => throw new NotImplementedException(nameof(filter))
        };
          
        /// <inheritdoc />
		public IRgbFilter GetColorFilter(RgbColors color)
        {        
            return new ColorFilter(
                    _factory.Get(color)
            );
        }
    }
}
