using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Factories;
using ImageProcessing.App.ServiceLayer.Models.Rgb;

namespace ImageProcessing.App.ServiceLayer.Services.Factories.Rgb
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
