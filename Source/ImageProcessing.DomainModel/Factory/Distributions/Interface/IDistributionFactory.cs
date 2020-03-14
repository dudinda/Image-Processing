using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Factory.Filter;
using ImageProcessing.DomainModel.Model.Distributions.Interface;

namespace ImageProcessing.DomainModel.Factory.Distributions.Interface
{
    /// <summary>
    /// Interface that DistributionFactory methods are required to implement.
    /// </summary>
    public interface IDistributionFactory : IFilterFactory<IDistribution, Distribution>
    {

    }
}
