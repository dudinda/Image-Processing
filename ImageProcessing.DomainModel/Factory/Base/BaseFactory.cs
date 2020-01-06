using ImageProcessing.DomainModel.Factory.Filters.Interface;
using ImageProcessing.Factory.Filters.Convolution;
using ImageProcessing.Factory.Filters.Distributions;
using ImageProcessing.Factory.Filters.RGBFilters;

namespace ImageProcessing.Factory.Base
{
    public class BaseFactory : IBaseFactory
    {
        public IConvolutionFilterFactory GetConvolutionFilterFactory()
        {
            return new ConvolutionFilterFactory();
        }

        public IDistributionFactory GetDistributionFactory()
        {
            return new DistributionFactory();
        }

        public IRGBFiltersFactory GetRGBFilterFactory()
        {
            return new RGBFiltersFactory();
        }
    }
}
