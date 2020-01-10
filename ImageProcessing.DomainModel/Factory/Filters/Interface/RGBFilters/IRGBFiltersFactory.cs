using ImageProcessing.Common.Enums;
using ImageProcessing.RGBFilters.Interface;

namespace ImageProcessing.DomainModel.Factory.Filters.Interface
{
    public interface IRGBFiltersFactory : IFilterFactory<IRGBFilter>
    {
        IRGBFilter GetColorFilter(RGBColors color);
    }
}
