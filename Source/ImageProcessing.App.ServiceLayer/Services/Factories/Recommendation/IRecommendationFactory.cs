using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Factories;
using ImageProcessing.App.ServiceLayer.Models.Recommendation;

namespace ImageProcessing.App.ServiceLayer.Services.Factories.Recommendation
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IRecommendation"/>.
    /// </summary>
    public interface IRecommendationFactory : IModelFactory<IRecommendation, Luma>
    {

    }
}
