using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Factories;
using ImageProcessing.App.ServiceLayer.Models.Distribution;

namespace ImageProcessing.App.DomainLayer.Factories.Distribution.Interface
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IDistribution"/>.
    /// </summary>
    public interface IDistributionFactory : IModelFactory<IDistribution, PrDistribution>
    {

    }
}
