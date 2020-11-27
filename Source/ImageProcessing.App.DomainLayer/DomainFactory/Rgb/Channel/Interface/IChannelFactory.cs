using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainModel.Rgb.Channel.Interface;
using ImageProcessing.Microkernel.MVP.Model;

namespace ImageProcessing.App.DomainLayer.DomainFactory.Rgb.Channel.Interface
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IChannel"/>.
    /// </summary>
    public interface IChannelFactory : IModelFactory<IChannel, RgbChannels>
    {

    }
}
