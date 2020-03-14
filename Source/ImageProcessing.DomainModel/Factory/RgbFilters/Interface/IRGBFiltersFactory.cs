using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Factory.Filter;
using ImageProcessing.DomainModel.Model.RgbFilters.Interface;

namespace ImageProcessing.DomainModel.Factory.RgbFilters.Interface
{
    /// <summary>
    /// Interface that RGBFilterFactory methods are required to implement.
    /// </summary>
    public interface IRGBFiltersFactory : IFilterFactory<IRGBFilter, RGBFilter>
    {
        IRGBFilter GetColorFilter(RGBColors color);
    }
}
