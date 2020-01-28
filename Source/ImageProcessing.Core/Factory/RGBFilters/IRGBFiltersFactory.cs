using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Factory.Filter;
using ImageProcessing.Core.Model.RGBFilters;

namespace ImageProcessing.Core.Factory.RGBFiltersFactory
{
    public interface IRGBFiltersFactory : IFilterFactory<IRGBFilter, RGBFilter>
    {
        IRGBFilter GetColorFilter(RGBColors color);
    }
}
