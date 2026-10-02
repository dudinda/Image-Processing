using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Factories.Rotation.Interface;
using ImageProcessing.App.DomainLayer.Models.Rotation.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Rotation.Interface;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Rotation.Implementation
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
