using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainModel.RgbFilters.Interface;
using ImageProcessing.Microkernel.MVP.Model;

namespace ImageProcessing.App.DomainLayer.Factory.RgbFilters.Rgb.Interface
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IRgbFilter"/>.
    /// </summary>
    public interface IRgbFilterFactory : IModelFactory<IRgbFilter, RgbFilter>
    {
        /// <summary>
        /// Provides a factory method for all the <see cref="RgbColors"/>
        /// implementing the <see cref="IRgbFilter"/>.
        /// </summary>
        IRgbFilter Get(RgbColors color);
    }
}
