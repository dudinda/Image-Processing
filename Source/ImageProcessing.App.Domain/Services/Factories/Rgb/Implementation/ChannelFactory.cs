using System;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Models.Rgb;
using ImageProcessing.App.Domain.Models.Rgb.Channel.Implementation;

namespace ImageProcessing.App.Domain.Services.Factories.Rgb.Implementation
{
    /// <inheritdoc cref="IChannelFactory"/>
    public sealed class ChannelFactory : IChannelFactory
    {
        /// <summary>
        /// Provides a factory method for all the <see cref="RgbChannels"/>
        /// implementing the <see cref="IChannel"/>.
        /// </summary>
        public IChannel Get(RgbChannels filter)
            => filter
        switch
        {
            RgbChannels.Red
                => new RChannel(),
            RgbChannels.Green
                => new GChannel(),
            RgbChannels.Blue
                => new BChannel(),
            RgbChannels.Red | RgbChannels.Green
                => new RGChannel(),
            RgbChannels.Red | RgbChannels.Blue
                => new RBChannel(),
            RgbChannels.Green | RgbChannels.Blue
                => new BGChannel(),
            RgbChannels.Green | RgbChannels.Blue | RgbChannels.Red
                => new RGBChannel(),

            _   => throw new NotSupportedException(nameof(filter))
        };
    }
}
