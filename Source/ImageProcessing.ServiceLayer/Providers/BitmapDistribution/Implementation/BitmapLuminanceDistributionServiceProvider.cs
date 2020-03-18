using System;
using System.Drawing;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Helpers;
using ImageProcessing.DomainModel.Factory.Distributions.Interface;
using ImageProcessing.ServiceLayer.Providers.Interface.BitmapDistribution;
using ImageProcessing.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.ServiceLayer.Services.Distributions.BitmapLuminance.Interface;

namespace ImageProcessing.ServiceLayer.Providers.Implementation.BitmapDistribution
{
    public sealed class BitmapLuminanceDistributionServiceProvider
        : IBitmapLuminanceDistributionServiceProvider
    {
        private readonly IBitmapLuminanceDistributionService _service;
        private readonly IDistributionFactory _factory;
        private readonly ICacheService<Bitmap> _cache;

        public BitmapLuminanceDistributionServiceProvider
            (IBitmapLuminanceDistributionService service,
             IDistributionFactory factory,
             ICacheService<Bitmap> cache)
        {
            _service = Requires.IsNotNull(
                service, nameof(service));
            _factory = Requires.IsNotNull(
                factory, nameof(factory));
            _cache = Requires.IsNotNull(
                cache, nameof(cache));
        }

        public Bitmap Transform(Bitmap bmp, Distribution distribution, (string, string) parms)
        {
            Requires.IsNotNull(bmp, nameof(bmp));

            return _cache.GetOrCreate(distribution,
                () =>
                _service.Transform(bmp,
                    _factory.GetFilter(distribution)
                        .SetParams(parms)
                )
            );
        }

        public decimal GetInfo(Bitmap bmp, RandomVariable info)
        {
            Requires.IsNotNull(bmp, nameof(bmp));

            switch (info)
            {
                case RandomVariable.Expectation:
                    return _service.GetExpectation(bmp);
                case RandomVariable.Entropy:
                    return _service.GetEntropy(bmp);
                case RandomVariable.Variance:
                    return _service.GetVariance(bmp);
                case RandomVariable.StandardDeviation:
                    return _service.GetStandardDeviation(bmp);

                default: throw new NotImplementedException(nameof(info));
            }
        }
    }
}
