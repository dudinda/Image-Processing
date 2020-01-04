using ImageProcessing.Common.Enum;
using ImageProcessing.RGBFilters.Abstract;

namespace ImageProcessing.Factory.Abstract
{
    public interface IRGBFiltersFactory
    {
        IRGBFilter GetFilter(RGBFilter filter);
    }
}
