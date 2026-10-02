using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.Domain.Rotation.Interface;
using ImageProcessing.App.Domain.Models.Rotation;
using ImageProcessing.App.Domain.Services.Factories.Rotation;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.Domain.Rotation.Implementation
{
    internal class RotationFactoryWrapper : IRotationFactoryWrapper
    {
        private readonly IRotationFactory _factory;

        public RotationFactoryWrapper(IRotationFactory factory)
        {
            _factory = factory;
        }

        public virtual IRotation Get(RotationMethod model)
            => _factory.Get(model);
    }
}
