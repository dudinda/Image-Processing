using System.Collections.Generic;
using System.Drawing;

using ImageProcessing.App.CommonLayer.Attributes;
using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.TypeExt;
using ImageProcessing.App.DomainLayer.Factory.Distribution.Interface;
using ImageProcessing.App.ServiceLayer.Providers.Interface.BitmapDistribution;
using ImageProcessing.App.ServiceLayer.Services.Distributions.BitmapLuminance.Interface;
using ImageProcessing.App.ServiceLayer.Visitors.BitmapLuminance.Factory.Interface;
using ImageProcessing.App.ServiceLayer.Visitors.BitmapLuminance.Visitor.Interface;

namespace ImageProcessing.App.ServiceLayer.Providers.Implementation.BitmapDistribution
{
    /// <inheritdoc cref="IBitmapLuminanceServiceProvider"/>
    internal sealed class BitmapLuminanceServiceProvider
        : IBitmapLuminanceServiceProvider
    {
        private readonly IBitmapLuminanceDistributionService _service;
        private readonly IDistributionFactory _factory;
        private readonly IBitmapLuminanceVisitor _visitor;
        private readonly IBitmapLuminanceVisitableFactory _info;

        public BitmapLuminanceServiceProvider(
            IBitmapLuminanceDistributionService service,
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
        public Bitmap Transform(Bitmap bmp, Distributions distribution, (string, string) parms)
            =>  _service.Transform(bmp, _factory.Get(distribution).SetParams(parms));

        /// <inheritdoc/>
        public decimal GetInfo(Bitmap bmp, RandomVariableInfo info)
            => _info.Get(info).Accept(_visitor).GetInfo(bmp);
    }
}
