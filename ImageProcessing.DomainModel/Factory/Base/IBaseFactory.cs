using ImageProcessing.DomainModel.Factory.Filters.Interface;

namespace ImageProcessing.Factory.Base
{
    public interface IBaseFactory
    {
        IDistributionFactory GetDistributionFactory();
        IConvolutionFilterFactory GetConvolutionFilterFactory();
        IRGBFiltersFactory GetRGBFilterFactory();
    }
}
