using ImageProcessing.DomainModel.Factory.Filters.Interface;

namespace ImageProcessing.Factory.Abstract
{
    public interface IBaseFactory
    {
        IDistributionFactory GetDistributionFactory();
        IConvolutionFilterFactory GetConvolutionFilterFactory();
        IRGBFiltersFactory GetRGBFilterFactory();
    }
}
