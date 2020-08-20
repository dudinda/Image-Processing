using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.BitmapLuminance;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.BitmapLuminance.Entropy;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.BitmapLuminance.Expectation;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.BitmapLuminance.StandardDeviation;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.BitmapLuminance.Variance;
using ImageProcessing.App.ServiceLayer.ServiceModel.VisitableFactory.BitmapLuminance.Interface;

namespace ImageProcessing.App.ServiceLayer.ServiceModel.VisitableFactory.BitmapLuminance.Implementation
{
    internal sealed class BitmapLuminanceVisitableFactory : IBitmapLuminanceVisitableFactory
    {
        public IBitmapLuminanceVisitable Get(RandomVariableInfo filter)
            => filter
        switch
        {
            RandomVariableInfo.Entropy
                => new BitmapLuminanceEntropyVisitable(),
            RandomVariableInfo.Expectation
                => new BitmapLuminanceExpectationVisitable(),
            RandomVariableInfo.Variance
                => new BitmapLuminanceVarianceVisitable(),
            RandomVariableInfo.StandardDeviation
                => new BitmapLuminanceStandardDeviationVisitable(),

            _ => throw new NotImplementedException(nameof(filter))
        }; 
    }
}
