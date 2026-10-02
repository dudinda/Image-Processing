using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Rotation.Interface;
using ImageProcessing.App.ServiceLayer.Models.Rotation;
using ImageProcessing.App.ServiceLayer.Services.Factories.Rotation;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Rotation.Implementation
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
