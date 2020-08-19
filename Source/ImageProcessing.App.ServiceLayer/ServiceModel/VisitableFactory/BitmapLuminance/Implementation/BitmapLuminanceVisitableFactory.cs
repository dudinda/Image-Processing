using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.ServiceLayer.Visitors.BitmapLuminance.Factory.Interface;
using ImageProcessing.App.ServiceLayer.Visitors.BitmapLuminance.Models;
using ImageProcessing.App.ServiceLayer.Visitors.BitmapLuminance.Models.Entropy;
using ImageProcessing.App.ServiceLayer.Visitors.BitmapLuminance.Models.Expectation;
using ImageProcessing.App.ServiceLayer.Visitors.BitmapLuminance.Models.StandardDeviation;
using ImageProcessing.App.ServiceLayer.Visitors.BitmapLuminance.Models.Variance;

namespace ImageProcessing.App.ServiceLayer.Visitors.BitmapLuminance.Factory.Implementation
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
