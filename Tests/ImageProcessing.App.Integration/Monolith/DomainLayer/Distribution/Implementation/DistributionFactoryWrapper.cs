using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Distribution.Interface;
using ImageProcessing.App.ServiceLayer.Models.Distribution;
using ImageProcessing.App.ServiceLayer.Services.Factories.Distribution;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Distribution.Implementation
{
    internal class DistributionFactoryWrapper : IDistributionFactoryWrapper
    {
        private readonly IDistributionFactory _factory;

        public DistributionFactoryWrapper(IDistributionFactory factory)
        {
            _factory = factory;
        }

        public virtual IDistribution Get(PrDistribution model)
            => _factory.Get(model);
    }
}
