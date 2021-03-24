using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.Rotation.Interface;
using ImageProcessing.App.DomainLayer.DomainModel.Rotation.Interface;
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
