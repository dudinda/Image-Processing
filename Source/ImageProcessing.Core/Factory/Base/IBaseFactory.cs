using ImageProcessing.Core.Factory.Convolution;
using ImageProcessing.Core.Factory.Distribution;
using ImageProcessing.Core.Factory.RGBFilters;

namespace ImageProcessing.Core.Factory.Base
{
    public interface IBaseFactory
    {
        IDistributionFactory GetDistributionFactory();
        IConvolutionFilterFactory GetConvolutionFilterFactory();
        IRGBFiltersFactory GetRGBFilterFactory();
    }
}
