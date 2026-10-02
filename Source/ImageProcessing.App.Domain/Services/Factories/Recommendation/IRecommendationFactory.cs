using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Factories;
using ImageProcessing.App.Domain.Models.Recommendation;

namespace ImageProcessing.App.Domain.Services.Factories.Recommendation
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IRecommendation"/>.
    /// </summary>
    public interface IRecommendationFactory : IModelFactory<IRecommendation, Luma>
    {

    }
}
