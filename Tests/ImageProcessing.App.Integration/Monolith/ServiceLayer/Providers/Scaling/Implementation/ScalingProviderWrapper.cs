using System.Drawing;

using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Scaling.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Scaling.Interface;
using ImageProcessing.App.ServiceLayer.Models.AppSettings;
using ImageProcessing.App.ServiceLayer.Providers.Scaling.Implementation;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Scaling.Implementation
{
    internal class ScalingProviderWrapper : IScalingProviderWrapper
    {
        private readonly ScalingProvider _provider;

        public IScalingFactoryWrapper ScalingFactory { get; }
        public AppSettings Settings { get; }

        public ScalingProviderWrapper(
            IScalingFactoryWrapper factory,
            AppSettings settings)
        {
            ScalingFactory = factory;
            Settings = settings;

            _provider = new ScalingProvider(factory, settings);
        }
        public virtual Bitmap Scale(Bitmap bmp, double xScale, double yScale)
            => _provider.Scale(bmp, xScale, yScale);

        public virtual Bitmap Scale(Bitmap bmp, double xScale, double yScale, ScalingMethod method)
            => _provider.Scale(bmp, xScale, yScale, method);
    }
}
