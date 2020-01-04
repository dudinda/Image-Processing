using ImageProcessing.Factory.Abstract;
using ImageProcessing.Factory.RGBFilters;
using ImageProcessing.DomainModel.Factory.Filters.Interface;

namespace ImageProcessing.Factory
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
