using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.DomainFactory.Scaling.Interface;
using ImageProcessing.App.ServiceLayer.Providers.Scaling.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Zoom.Interface;
using ImageProcessing.App.ServiceLayer.Services.Settings.Interface;

namespace ImageProcessing.App.ServiceLayer.Providers.Scaling.Implementation
{
    internal sealed class ScalingProvider : IScalingProvider
    {
        private readonly IScalingFactory _factory;
        private readonly IAppSettings _settings;
        private readonly IAsyncZoomLocker _locker;

        public ScalingProvider(
            IScalingFactory factory,
            IAppSettings settings,
            IAsyncZoomLocker locker)
        {
            _factory = factory;
            _settings = settings;
            _locker = locker;
        }

        public async Task<Bitmap> Scale(Bitmap bmp, double yScale, double xScale)
            => await _locker.LockZoomAsync(
                () => _factory.Get(_settings.Scaling).Resize(bmp, yScale, xScale)
            ).ConfigureAwait(false);       
    }
}
