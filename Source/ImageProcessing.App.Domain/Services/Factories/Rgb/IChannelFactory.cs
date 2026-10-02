using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Factories;
using ImageProcessing.App.Domain.Models.Rgb;

namespace ImageProcessing.App.Domain.Services.Factories.Rgb
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IChannel"/>.
    /// </summary>
    public interface IChannelFactory : IModelFactory<IChannel, RgbChannels>
    {

    }
}
