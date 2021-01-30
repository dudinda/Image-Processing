using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainModel.Distribution.Interface;

namespace ImageProcessing.App.DomainLayer.DomainFactory.Distribution.Interface
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IDistribution"/>.
    /// </summary>
    public interface IDistributionFactory : IModelFactory<IDistribution, PrDistribution>
    {

    }
}
