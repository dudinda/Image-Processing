using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Factory;
using ImageProcessing.DomainModel.Model.RgbFilters.Interface;

namespace ImageProcessing.DomainModel.Factory.RgbFilters.Rgb.Interface
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IRgbFilter"/>.
    /// </summary>
    public interface IRgbFilterFactory : IBaseFactory<IRgbFilter, RgbFilter>
    {
        /// <summary>
        /// Provides a factory method for all <see cref="RgbColors"/>
        /// implementing <see cref="IRgbFilter"/>.
        /// </summary>
        IRgbFilter GetColorFilter(RgbColors color);
    }
}
