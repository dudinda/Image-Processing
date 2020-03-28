using ImageProcessing.Common.Enums;
using ImageProcessing.DomainModel.Factory.Base;
using ImageProcessing.DomainModel.Model.Distributions.Interface;

namespace ImageProcessing.DomainModel.Factory.Distributions.Interface
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IDistribution"/>.
    /// </summary>
    public interface IDistributionFactory : IBaseFactory<IDistribution, Distribution>
    {

    }
}
