using System.Drawing;

using ImageProcessing.App.Domain.Models.Options;
using ImageProcessing.App.Domain.Providers.Rotation;
using ImageProcessing.App.Domain.Services.Factories.Rotation;

namespace ImageProcessing.App.Domain.Providers.Rotation.Implementation
{
    public sealed class RotationProvider : IRotationProvider
    {
        private readonly IRotationFactory _rotation;
        private readonly SettingsOptions _settings;

        public RotationProvider(
            IRotationFactory rotation,
            SettingsOptions settings)
        {
            _rotation = rotation;
            _settings = settings;
        }
        public Bitmap Rotate(Bitmap bmp, double angle)
            => _rotation.Get(_settings.Rotation).Rotate(bmp, angle);
    }
}
