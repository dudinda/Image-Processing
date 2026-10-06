using System.Drawing;

using ImageProcessing.App.Integration.Monolith.Domain.Providers.Rotation.Interface;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Rotation.Interface;
using ImageProcessing.App.Domain.Providers.Rotation.Implementation;
using ImageProcessing.App.Domain.Models.Options;

namespace ImageProcessing.App.Integration.Monolith.Domain.Providers.Rotation.Implementation
{
    internal class RotationProviderWrapper : IRotationProviderWrapper
    {
        private readonly RotationProvider _provider;

        public IRotationFactoryWrapper Rotation { get; }
        public SettingsOptions Settings { get; }

        public RotationProviderWrapper(
            IRotationFactoryWrapper rotation,
            SettingsOptions settings)
        {
            Rotation = rotation;
            Settings = settings;

            _provider = new RotationProvider(rotation, settings);
        }

        public virtual Bitmap Rotate(Bitmap bmp, double angle)
            => _provider.Rotate(bmp, angle);
    }
}
