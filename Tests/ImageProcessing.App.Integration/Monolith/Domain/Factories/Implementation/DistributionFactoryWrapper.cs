using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Distribution.Interface;
using ImageProcessing.App.Domain.Models.Distribution;
using ImageProcessing.App.Domain.Services.Factories.Distribution;

namespace ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Distribution.Implementation
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
