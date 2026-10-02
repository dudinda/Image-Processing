using System.Drawing;

using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Rotation.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Rotation.Interface;
using ImageProcessing.App.ServiceLayer.Models.AppSettings;
using ImageProcessing.App.ServiceLayer.Providers.Rotation.Implementation;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Rotation.Implementation
{
    internal class RotationProviderWrapper : IRotationProviderWrapper
    {
        private readonly RotationProvider _provider;

        public IRotationFactoryWrapper Rotation { get; }
        public AppSettings Settings { get; }

        public RotationProviderWrapper(
            IRotationFactoryWrapper rotation,
            AppSettings settings)
        {
            Rotation = rotation;
            Settings = settings;

            _provider = new RotationProvider(rotation, settings);
        }

        public virtual Bitmap Rotate(Bitmap bmp, double angle)
            => _provider.Rotate(bmp, angle);
    }
}
