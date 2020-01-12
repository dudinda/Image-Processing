using ImageProcessing.DomainModel.Factory.Filters.Interface;

namespace ImageProcessing.Factory.Base
{
    /// <summary>
    /// Interface that BaseFacotory methods are required to implement.
    /// </summary>
    /// <seealso cref="BaseFactory"/>
    public interface IBaseFactory
    {
        IDistributionFactory GetDistributionFactory();
        IConvolutionFilterFactory GetConvolutionFilterFactory();
        IRGBFiltersFactory GetRGBFilterFactory();
    }
}
