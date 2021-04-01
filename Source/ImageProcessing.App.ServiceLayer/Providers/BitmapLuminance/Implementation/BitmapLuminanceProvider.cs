using System.Drawing;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.Distribution.Interface;
using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Providers.Interface.BitmapDistribution;
using ImageProcessing.App.ServiceLayer.ServiceModel.VisitableFactory.BitmapLuminance.Interface;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitors.BitmapLuminance.Interface;
using ImageProcessing.App.ServiceLayer.Services.Distribution.BitmapLuminance.Interface;

namespace ImageProcessing.App.ServiceLayer.Providers.Implementation.BitmapDistribution
{
    /// <inheritdoc cref="IBitmapLuminanceProvider"/>
    public sealed class BitmapLuminanceProvider
        : IBitmapLuminanceProvider
    {
        private readonly IBitmapLuminanceService _service;
        private readonly IDistributionFactory _factory;
        private readonly IBitmapLuminanceVisitor _visitor;
        private readonly IBitmapLuminanceVisitableFactory _info;

        public BitmapLuminanceProvider(
            IBitmapLuminanceService service,
            IBitmapLuminanceVisitableFactory info,
            IBitmapLuminanceVisitor visitor,
            IDistributionFactory factory)
        {
            _service = service;
            _factory = factory;
            _info = info;
            _visitor = visitor;
        }

        /// <inheritdoc/>
        public Bitmap Transform(Bitmap bmp, PrDistribution distribution, (string, string) parms)
            =>  _service.Transform(bmp, _factory.Get(distribution).SetParams(parms));

        /// <inheritdoc/>
        public decimal GetInfo(Bitmap bmp, RndInfo info)
            => _info.Get(info).Accept(_visitor).GetInfo(bmp);
    }
}
