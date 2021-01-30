using System;

using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.BitmapLuminance;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.BitmapLuminance.Entropy;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.BitmapLuminance.Expectation;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.BitmapLuminance.StandardDeviation;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.BitmapLuminance.Variance;
using ImageProcessing.App.ServiceLayer.ServiceModel.VisitableFactory.BitmapLuminance.Interface;

namespace ImageProcessing.App.ServiceLayer.ServiceModel.VisitableFactory.BitmapLuminance.Implementation
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
