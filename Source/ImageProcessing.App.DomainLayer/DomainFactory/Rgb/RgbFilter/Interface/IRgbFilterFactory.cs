using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainModel.Rgb.RgbFilter.Interface;
using ImageProcessing.Microkernel.MVP.Model;

namespace ImageProcessing.App.DomainLayer.DomainFactory.Rgb.RgbFilter.Interface
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IRgbFilter"/>.
    /// </summary>
    public interface IRgbFilterFactory : IModelFactory<IRgbFilter, RgbFltr>
    {
        /// <summary>
        /// Provides a factory method for all the <see cref="RgbChannels"/>
        /// implementing the <see cref="IRgbFilter"/>.
        /// </summary>
        IRgbFilter Get(RgbChannels color);
    }
}
