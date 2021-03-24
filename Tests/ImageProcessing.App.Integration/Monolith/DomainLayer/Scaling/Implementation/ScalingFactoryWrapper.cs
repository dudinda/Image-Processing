using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.Scaling.Interface;
using ImageProcessing.App.DomainLayer.DomainModel.Scaling.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Scaling.Interface;

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
