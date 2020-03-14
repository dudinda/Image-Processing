using System;
using System.Drawing;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Helpers;
using ImageProcessing.Core.Factory.DistributionFactory;
using ImageProcessing.Core.ServiceLayer.Providers.BitmapDistribution;
using ImageProcessing.ServiceLayer.Service.DistributionServices.BitmapLuminanceDistribution.Interface;

namespace ImageProcessing.ServiceLayer.Providers.BitmapDistribution
{
    public class BitmapLuminanceDistributionServiceProvider
        : IBitmapLuminanceDistributionServiceProvider
    {
        private readonly IBitmapLuminanceDistributionService _service;
        private readonly IDistributionFactory _factory;

        public BitmapLuminanceDistributionServiceProvider
            (IBitmapLuminanceDistributionService service,
             IDistributionFactory factory)
        {
            _service = Requires.IsNotNull(
                service, nameof(service)
            );

            _factory = Requires.IsNotNull(
                factory, nameof(factory)
            );
        }

        public Bitmap Transform(Bitmap bmp, Distribution distribution, (string, string) parms)
        {
            Requires.IsNotNull(bmp, nameof(bmp));

            return _service.TransformTo(bmp,
                _factory.GetFilter(distribution)
                        .SetParams(parms)
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
