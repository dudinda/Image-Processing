using System.Drawing;

using ImageProcessing.App.DomainLayer.DomainFactory.Scaling.Interface;
using ImageProcessing.App.ServiceLayer.Providers.Scaling.Interface;
using ImageProcessing.App.ServiceLayer.Services.Settings.Interface;

namespace ImageProcessing.App.ServiceLayer.Providers.Scaling.Implementation
{
    public sealed class ScalingProvider : IScalingProvider
    {
        private readonly IScalingFactory _factory;
        private readonly IAppSettings _settings;

        public ScalingProvider( 
            IScalingFactory factory,
            IAppSettings settings)
        {
            _factory = factory;
            _settings = settings;
        }

        public Bitmap Scale(Bitmap bmp, double xScale, double yScale)
            => _factory.Get(_settings.Scaling).Resize(bmp, xScale, yScale);
    }
}
