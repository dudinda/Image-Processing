using ImageProcessing.App.Common.Enums;
using ImageProcessing.App.DomainModel.Model.Distributions.Interface;
using ImageProcessing.Microkernel.MVP.Model;

namespace ImageProcessing.App.DomainModel.Factory.Distributions.Interface
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IDistribution"/>.
    /// </summary>
    public interface IDistributionFactory : IModelFactory<IDistribution, Distribution>
    {

    }
}
