using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.Model.Distributions.Interface;
using ImageProcessing.Microkernel.MVP.Model;

namespace ImageProcessing.App.DomainLayer.Factory.Distributions.Interface
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IDistribution"/>.
    /// </summary>
    public interface IDistributionFactory : IModelFactory<IDistribution, CommonLayer.Enums.Distributions>
    {

    }
}
