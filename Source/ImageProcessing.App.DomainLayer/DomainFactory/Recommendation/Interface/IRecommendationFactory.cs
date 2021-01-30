using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainModel.Recommendation.Interface;

namespace ImageProcessing.App.DomainLayer.DomainFactory.RgbFilters.Recommendation.Interface
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IRecommendation"/>.
    /// </summary>
    public interface IRecommendationFactory : IModelFactory<IRecommendation, Luma>
    {

    }
}
