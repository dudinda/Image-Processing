using ImageProcessing.Core.Factory.Base;
using ImageProcessing.Core.Factory.Convolution;
using ImageProcessing.Core.Factory.Distribution;
using ImageProcessing.Core.Factory.RGBFilters;
using ImageProcessing.Factory.Filters.Convolution;
using ImageProcessing.Factory.Filters.Distributions;
using ImageProcessing.Factory.Filters.RGBFilters;

namespace ImageProcessing.Factory.Base
{
    public class BaseFactory : IBaseFactory
    {
        public IConvolutionFilterFactory GetConvolutionFilterFactory()
            => new ConvolutionFilterFactory();
        
        public IDistributionFactory GetDistributionFactory()
            => new DistributionFactory();
        
        public IRGBFiltersFactory GetRGBFilterFactory()
            => new RGBFiltersFactory();
        
    }
}
