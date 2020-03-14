using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Factory;
using ImageProcessing.DomainModel.Model.RgbFilters.Interface;

namespace ImageProcessing.DomainModel.Factory.RgbFilters.Interface
{
    /// <summary>
    /// Interface that RGBFilterFactory methods are required to implement.
    /// </summary>
    public interface IRgbFilterFactory : IBaseFactory<IRgbFilter, RgbFilter>
    {
        IRgbFilter GetColorFilter(RgbColors color);
    }
}
