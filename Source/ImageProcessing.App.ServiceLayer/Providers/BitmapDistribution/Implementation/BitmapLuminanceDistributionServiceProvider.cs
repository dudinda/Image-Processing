using System;
using System.Drawing;

using ImageProcessing.App.Common.Enums;
using ImageProcessing.App.Common.Helpers;
using ImageProcessing.App.DomainModel.Factory.Distributions.Interface;
using ImageProcessing.App.ServiceLayer.Providers.Interface.BitmapDistribution;
using ImageProcessing.App.ServiceLayer.Services.Distributions.BitmapLuminance.Interface;

namespace ImageProcessing.App.ServiceLayer.Providers.Implementation.BitmapDistribution
{
    public sealed class BitmapLuminanceDistributionServiceProvider
        : IBitmapLuminanceDistributionServiceProvider
    {
        private readonly IBitmapLuminanceDistributionService _service;
        private readonly IDistributionFactory _factory;

        public BitmapLuminanceDistributionServiceProvider
            (IBitmapLuminanceDistributionService service,
             IDistributionFactory factory)
        {
            _service = Requires.IsNotNull(
                service, nameof(service));
            _factory = Requires.IsNotNull(
                factory, nameof(factory));
        }

        public Bitmap Transform(Bitmap bmp, Distribution distribution, (string, string) parms)
        {
            Requires.IsNotNull(bmp, nameof(bmp));

            return  _service.Transform(bmp,
                        _factory.Get(distribution)
                            .SetParams(parms)
            );
        }

        public decimal GetInfo(Bitmap bmp, RandomVariableInfo info)
        {
            Requires.IsNotNull(bmp, nameof(bmp));

            switch (info)
            {
                case RandomVariableInfo.Expectation:
                    return _service.GetExpectation(bmp);
                case RandomVariableInfo.Entropy:
                    return _service.GetEntropy(bmp);
                case RandomVariableInfo.Variance:
                    return _service.GetVariance(bmp);
                case RandomVariableInfo.StandardDeviation:
                    return _service.GetStandardDeviation(bmp);

                default: throw new NotImplementedException(nameof(info));
            }
        }
    }
}
