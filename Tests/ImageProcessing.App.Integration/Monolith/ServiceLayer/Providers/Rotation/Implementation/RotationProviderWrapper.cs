using System.Drawing;

using ImageProcessing.App.DomainLayer.Models.AppSettings.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Rotation.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Rotation.Interface;
using ImageProcessing.App.ServiceLayer.Providers.Rotation.Implementation;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Rotation.Implementation
{
    internal class RotationProviderWrapper : IRotationProviderWrapper
    {
        private readonly RotationProvider _provider;

        public IRotationFactoryWrapper Rotation { get; }
        public IAppSettings Settings { get; }

        public RotationProviderWrapper(
            IRotationFactoryWrapper rotation,
            IAppSettings settings)
        {
            Rotation = rotation;
            Settings = settings;

            _provider = new RotationProvider(rotation, settings);
        }

        public virtual Bitmap Rotate(Bitmap bmp, double angle)
            => _provider.Rotate(bmp, angle);
    }
}
