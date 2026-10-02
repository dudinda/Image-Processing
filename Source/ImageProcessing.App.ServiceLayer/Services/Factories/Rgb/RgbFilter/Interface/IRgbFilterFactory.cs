using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Factories;
using ImageProcessing.App.ServiceLayer.Models.Rgb;

namespace ImageProcessing.App.DomainLayer.Factories.Rgb.RgbFilter.Interface
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
        IRgbFilter Get(RgbChannels channel);
    }
}
