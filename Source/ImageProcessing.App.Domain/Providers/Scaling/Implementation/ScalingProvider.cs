using System.Drawing;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Models.AppSettings;
using ImageProcessing.App.Domain.Providers.Scaling;
using ImageProcessing.App.Domain.Services.Factories.Scaling;

namespace ImageProcessing.App.Domain.Providers.Scaling.Implementation
{
    public sealed class ScalingProvider : IScalingProvider
    {
        private readonly IScalingFactory _factory;
        private readonly AppSettings _settings;

        public ScalingProvider( 
            IScalingFactory factory,
            AppSettings settings)
        {
            _factory = factory;
            _settings = settings;
        }

        public Bitmap Scale(Bitmap bmp, double xScale, double yScale)
            => _factory.Get(_settings.Scaling).Resize(bmp, xScale, yScale);

        public Bitmap Scale(Bitmap bmp, double xScale, double yScale, ScalingMethod method)
            => _factory.Get(method).Resize(bmp, xScale, yScale);
    }
}
