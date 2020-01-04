using ImageProcessing.Factory.RGBFilters;
using ImageProcessing.DomainModel.Factory.Filters.Interface;

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
