using System.Drawing;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Factories.Scaling.Interface;
using ImageProcessing.App.ServiceLayer.Models.AppSettings;
using ImageProcessing.App.ServiceLayer.Providers.Scaling.Interface;

namespace ImageProcessing.App.ServiceLayer.Providers.Scaling.Implementation
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
