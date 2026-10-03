using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Scaling.Interface;
using ImageProcessing.App.Domain.Models.Scaling;
using ImageProcessing.App.Domain.Services.Factories.Scaling;

namespace ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Scaling.Implementation
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
