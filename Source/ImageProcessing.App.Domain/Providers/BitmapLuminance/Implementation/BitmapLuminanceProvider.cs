using System.Drawing;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Providers.BitmapLuminance;
using ImageProcessing.App.Domain.Providers.VisitableFactory.BitmapLuminance;
using ImageProcessing.App.Domain.Providers.Visitors.BitmapLuminance;
using ImageProcessing.App.Domain.Services.Distribution;
using ImageProcessing.App.Domain.Services.Factories.Distribution;

namespace ImageProcessing.App.Domain.Providers.BitmapLuminance.Implementation
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
