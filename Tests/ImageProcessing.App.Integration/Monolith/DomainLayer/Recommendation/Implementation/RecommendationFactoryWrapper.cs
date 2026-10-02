using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.Domain.Recommendation.Interface;
using ImageProcessing.App.Domain.Models.Recommendation;
using ImageProcessing.App.Domain.Services.Factories.Recommendation;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.Domain.Recommendation.Implementation
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
