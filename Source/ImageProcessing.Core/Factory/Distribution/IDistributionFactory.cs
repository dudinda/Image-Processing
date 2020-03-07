using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Factory.Filter;
using ImageProcessing.Core.Model.Distribution;

namespace ImageProcessing.Core.Factory.DistributionFactory
{
    /// <summary>
    /// Interface that DistributionFactory methods are required to implement.
    /// </summary>
    public interface IDistributionFactory : IFilterFactory<IDistribution, Distribution>
    {

    }
}
