using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.DomainModel.Factory.RgbFilters.Color.Interface;
using ImageProcessing.DomainModel.Model.RgbFilters.Implementation.Color.Colors;
using ImageProcessing.DomainModel.Model.RgbFilters.Interface.Color;

namespace ImageProcessing.DomainModel.Factory.RgbFilters.Color.Implementation
{
    /// <inheritdoc cref="IColorFactory"/>
    public sealed class ColorFactory : IColorFactory
    {
        /// <summary>
        /// Provides a factory method for all <see cref="RgbColors"/>
        /// implementing <see cref="IColor"/>.
        /// </summary>
        public IColor Get(RgbColors filter)
            => filter switch
            {
                RgbColors.Red
                    => new RColor(),
                RgbColors.Green
                    => new GColor(),
                RgbColors.Blue
                    => new BColor(),
                RgbColors.Red | RgbColors.Green
                    => new RGColor(),
                RgbColors.Red | RgbColors.Blue
                    => new RBColor(),
                RgbColors.Green | RgbColors.Blue
                    => new BGColor(),
                RgbColors.Green | RgbColors.Blue | RgbColors.Red
                    => new RGBColor(),

                _   => throw new NotSupportedException(nameof(filter))
            };
     
    }
}
