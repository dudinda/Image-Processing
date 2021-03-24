using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.RgbFilters.Recommendation.Interface;
using ImageProcessing.App.DomainLayer.DomainModel.Recommendation.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Recommendation.Interface;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Recommendation.Implementation
{
    internal class RecommendationFactoryWrapper : IRecommendationFactoryWrapper
    {
        private readonly IRecommendationFactory _factory;

        public RecommendationFactoryWrapper(IRecommendationFactory factory)
        {
            _factory = factory;
        }

        public virtual IRecommendation Get(Luma model)
            => _factory.Get(model);
    }
}
