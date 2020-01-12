using ImageProcessing.DomainModel.Factory.Filters.Interface;
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
