using System.Drawing;

using ImageProcessing.App.DomainLayer.DomainFactory.Rotation.Interface;
using ImageProcessing.App.ServiceLayer.Providers.Rotation.Interface;
using ImageProcessing.App.ServiceLayer.Services.Settings.Interface;

namespace ImageProcessing.App.ServiceLayer.Providers.Rotation.Implementation
{
    internal sealed class RotationProvider : IRotationProvider
    {
        private readonly IRotationFactory _rotation;
        private readonly IAppSettings _settings;

        public RotationProvider(
            IRotationFactory rotation,
            IAppSettings settings)
        {
            _rotation = rotation;
            _settings = settings;
        }
        public Bitmap Rotate(Bitmap bmp, double angle)
            => _rotation.Get(_settings.Rotation).Rotate(bmp, angle);
    }
}
