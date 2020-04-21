using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.Model.Recommendation.Interface;
using ImageProcessing.Microkernel.MVP.Model;

namespace ImageProcessing.App.DomainLayer.Factory.RgbFilters.Recommendation.Interface
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IRecommendation"/>.
    /// </summary>
    public interface IRecommendationFactory : IModelFactory<IRecommendation, Luma>
    {

    }
}
