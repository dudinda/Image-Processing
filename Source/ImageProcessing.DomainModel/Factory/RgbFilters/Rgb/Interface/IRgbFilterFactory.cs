using ImageProcessing.Common.Enums;
using ImageProcessing.Core.MVP.Model;
using ImageProcessing.DomainModel.Model.RgbFilters.Interface;

namespace ImageProcessing.DomainModel.Factory.RgbFilters.Rgb.Interface
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
