using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Scaling.Interface;
using ImageProcessing.App.ServiceLayer.Models.Scaling;
using ImageProcessing.App.ServiceLayer.Services.Factories.Scaling;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Scaling.Implementation
{
    internal class ScalingFactoryWrapper : IScalingFactoryWrapper
    {
        private readonly IScalingFactory _factory;

        public ScalingFactoryWrapper(IScalingFactory factory)
        {
            _factory = factory;
        }

        public virtual IScaling Get(ScalingMethod model)
            => _factory.Get(model);
    }
}
