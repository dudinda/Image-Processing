using System.Drawing;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.BitmapLuminance.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.ServiceModel.VisitableFactory.BitmapLuminance.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.ServiceModel.Vistiors.BitmapLuminance.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Distribution.BitmapLuminance.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Distribution.Interface;
using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Providers.Implementation.BitmapDistribution;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.BitmapLuminance.Implementation
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
