using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.Histogram;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.Histogram.Cdf;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.Histogram.Pmf;
using ImageProcessing.App.ServiceLayer.ServiceModel.VisitableFactory.Histogram.Interface;

namespace ImageProcessing.App.ServiceLayer.ServiceModel.VisitableFactory.Histogram.Implementation
{
    internal sealed class HistogramVisitableFactory : IHistogramVisitableFactory
    {
        public IHistogramVisitable Get(RandomVariableFunction filter)
            => filter
        switch
        {
            RandomVariableFunction.PMF
                => new PmfHistogramVisitable(),
            RandomVariableFunction.CDF
                => new CdfHistogramVisitable(),

            _ => throw new NotImplementedException(nameof(filter))
        };    
    }
}
