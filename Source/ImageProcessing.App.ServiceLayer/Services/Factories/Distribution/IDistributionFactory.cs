using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Factories;
using ImageProcessing.App.ServiceLayer.Models.Distribution;

namespace ImageProcessing.App.ServiceLayer.Services.Factories.Distribution
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IDistribution"/>.
    /// </summary>
    public interface IDistributionFactory : IModelFactory<IDistribution, PrDistribution>
    {

    }
}
