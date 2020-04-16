using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Helpers;
using ImageProcessing.App.DomainModel.Factory.RgbFilters.Color.Interface;
using ImageProcessing.App.DomainModel.Factory.RgbFilters.Rgb.Interface;
using ImageProcessing.App.DomainModel.Model.RgbFilters.Implementation.Binary;
using ImageProcessing.App.DomainModel.Model.RgbFilters.Implementation.Color;
using ImageProcessing.App.DomainModel.Model.RgbFilters.Implementation.Grayscale;
using ImageProcessing.App.DomainModel.Model.RgbFilters.Implementation.Inversion;
using ImageProcessing.App.DomainModel.Model.RgbFilters.Interface;

namespace ImageProcessing.App.DomainModel.Factory.RgbFilters.Rgb.Implementation
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
        /// Provides a factory method for all the <see cref="RgbFilter"/>
        /// implementing the <see cref="IRgbFilter"/>.
        /// </summary>
        public IRgbFilter Get(RgbFilter filter)
            => filter
        switch
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
		public IRgbFilter Get(RgbColors color)
            => new ColorFilter(
                _factory.Get(color)
            );     
    }
}
