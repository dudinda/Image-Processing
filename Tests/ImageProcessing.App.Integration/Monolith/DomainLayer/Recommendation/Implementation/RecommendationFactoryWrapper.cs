using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Recommendation.Interface;
using ImageProcessing.App.ServiceLayer.Models.Recommendation;
using ImageProcessing.App.ServiceLayer.Services.Factories.Recommendation;

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
