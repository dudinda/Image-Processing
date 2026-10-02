using System.Drawing;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.BitmapLuminance.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.ServiceModel.VisitableFactory.BitmapLuminance.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.ServiceModel.Vistiors.BitmapLuminance.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Distribution.BitmapLuminance.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.Domain.Distribution.Interface;
using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Providers.BitmapLuminance.Implementation;

namespace ImageProcessing.App.Integration.Monolith.Domain.Providers.BitmapLuminance.Implementation
{
    internal class BitmapLuminanceProviderWrapper : IBitmapLuminanceProviderWrapper
    {
        private readonly BitmapLuminanceProvider _provider;

        public IBitmapLuminanceServiceWrapper BitmapLuminanceService { get; }
        public IBitmapLuminanceVisitableFactoryWrapper BitmapLuminanceVisitableFactory { get; }
        public IBitmapLuminanceVisitorWrapper BitmapLuminanceVisitor { get; }
        public IDistributionFactoryWrapper DistributionFactory { get; }

        public BitmapLuminanceProviderWrapper(
            IBitmapLuminanceServiceWrapper service,
            IBitmapLuminanceVisitableFactoryWrapper info,
            IBitmapLuminanceVisitorWrapper visitor,
            IDistributionFactoryWrapper factory)
        {
            BitmapLuminanceService = service;
            BitmapLuminanceVisitableFactory = info;
            BitmapLuminanceVisitor = visitor;
            DistributionFactory = factory;

            _provider = new BitmapLuminanceProvider(service, info, visitor, factory);
        }

        public virtual decimal GetInfo(Bitmap bmp, RndInfo info)
            => _provider.GetInfo(bmp, info);

        public virtual Bitmap Transform(Bitmap bmp, PrDistribution distribution, (string, string) parms)
            => _provider.Transform(bmp, distribution, parms);
    }
}
