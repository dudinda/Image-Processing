using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.Color.Interface;
using ImageProcessing.App.DomainLayer.DomainModel.Rgb.Color.Implementation;
using ImageProcessing.App.DomainLayer.DomainModel.Rgb.Color.Interface;

namespace ImageProcessing.App.DomainLayer.DomainFactory.Rgb.Color.Implementation
{
    /// <inheritdoc cref="IColorFactory"/>
    internal sealed class ColorFactory : IColorFactory
    {
        /// <summary>
        /// Provides a factory method for all the <see cref="RgbColors"/>
        /// implementing the <see cref="IColor"/>.
        /// </summary>
        public IColor Get(RgbColors filter)
            => filter
        switch
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

            _ => throw new NotSupportedException(nameof(filter))
        };
    }
}
