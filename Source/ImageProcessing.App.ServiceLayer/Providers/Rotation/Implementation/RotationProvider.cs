using System.Drawing;

using ImageProcessing.App.ServiceLayer.Models.AppSettings;
using ImageProcessing.App.ServiceLayer.Providers.Rotation;
using ImageProcessing.App.ServiceLayer.Services.Factories.Rotation;

namespace ImageProcessing.App.ServiceLayer.Providers.Rotation.Implementation
{
    public sealed class RotationProvider : IRotationProvider
    {
        private readonly IRotationFactory _rotation;
        private readonly AppSettings _settings;

        public RotationProvider(
            IRotationFactory rotation,
            AppSettings settings)
        {
            _rotation = rotation;
            _settings = settings;
        }
        public Bitmap Rotate(Bitmap bmp, double angle)
            => _rotation.Get(_settings.Rotation).Rotate(bmp, angle);
    }
}
