using System;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Providers.Visitable.BitmapLuminance;
using ImageProcessing.App.Domain.Providers.Visitable.BitmapLuminance.Entropy;
using ImageProcessing.App.Domain.Providers.Visitable.BitmapLuminance.Expectation;
using ImageProcessing.App.Domain.Providers.Visitable.BitmapLuminance.StandardDeviation;
using ImageProcessing.App.Domain.Providers.Visitable.BitmapLuminance.Variance;

namespace ImageProcessing.App.Domain.Providers.VisitableFactory.BitmapLuminance.Implementation
{
    public sealed class BitmapLuminanceVisitableFactory : IBitmapLuminanceVisitableFactory
    {
        public IBitmapLuminanceVisitable Get(RndInfo filter)
            => filter
        switch
        {
            RndInfo.Entropy
                => new BitmapLuminanceEntropyVisitable(),
            RndInfo.Expectation
                => new BitmapLuminanceExpectationVisitable(),
            RndInfo.Variance
                => new BitmapLuminanceVarianceVisitable(),
            RndInfo.StandardDeviation
                => new BitmapLuminanceStandardDeviationVisitable(),

            _   => throw new NotImplementedException(nameof(filter))
        }; 
    }
}
