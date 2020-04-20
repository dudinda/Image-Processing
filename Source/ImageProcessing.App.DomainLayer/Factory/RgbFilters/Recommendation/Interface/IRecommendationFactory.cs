using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.Model.Recommendation.Interface;
using ImageProcessing.Microkernel.MVP.Model;

namespace ImageProcessing.App.DomainLayer.Factory.RgbFilters.Recommendation.Interface
{
    public interface IRecommendationFactory : IModelFactory<IRecommendation, Luma>
    {

    }
}
