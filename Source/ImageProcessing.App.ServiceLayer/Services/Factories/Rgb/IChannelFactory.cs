using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Factories;
using ImageProcessing.App.ServiceLayer.Models.Rgb;

namespace ImageProcessing.App.ServiceLayer.Services.Factories.Rgb
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IChannel"/>.
    /// </summary>
    public interface IChannelFactory : IModelFactory<IChannel, RgbChannels>
    {

    }
}
