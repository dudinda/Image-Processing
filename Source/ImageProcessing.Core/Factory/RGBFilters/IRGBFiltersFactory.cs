using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Factory.Filter;
using ImageProcessing.Core.Model.RGBFilters;

namespace ImageProcessing.Core.Factory.RGBFilters
{
    public interface IRGBFiltersFactory : IFilterFactory<IRGBFilter>
    {
        IRGBFilter GetColorFilter(RGBColors color);
    }
}
