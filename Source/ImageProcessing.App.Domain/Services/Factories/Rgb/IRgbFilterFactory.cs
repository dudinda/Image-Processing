using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Factories;
using ImageProcessing.App.Domain.Models.Rgb;

namespace ImageProcessing.App.Domain.Services.Factories.Rgb
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
