using ImageProcessing.App.Common.Enums;
using ImageProcessing.Framework.Core.MVP.Model;
using ImageProcessing.App.DomainModel.Model.Distributions.Interface;

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
