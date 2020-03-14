using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Factory;
using ImageProcessing.DomainModel.Model.Distributions.Interface;

namespace ImageProcessing.DomainModel.Factory.Distributions.Interface
{
    /// <summary>
    /// Interface that DistributionFactory methods are required to implement.
    /// </summary>
    public interface IDistributionFactory : IBaseFactory<IDistribution, Distribution>
    {

    }
}
