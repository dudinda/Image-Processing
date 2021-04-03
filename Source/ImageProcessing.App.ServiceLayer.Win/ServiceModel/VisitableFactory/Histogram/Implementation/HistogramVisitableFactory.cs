using System;

using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Win.ServiceModel.Visitable.Histogram;
using ImageProcessing.App.ServiceLayer.Win.ServiceModel.Visitable.Histogram.Cdf;
using ImageProcessing.App.ServiceLayer.Win.ServiceModel.Visitable.Histogram.Pmf;
using ImageProcessing.App.ServiceLayer.Win.ServiceModel.VisitableFactory.Histogram.Interface;

namespace ImageProcessing.App.ServiceLayer.Win.ServiceModel.VisitableFactory.Histogram.Implementation
{
    public sealed class HistogramVisitableFactory : IHistogramVisitableFactory
    {
        public IHistogramVisitable Get(RndFunction filter)
            => filter
        switch
        {
            RndFunction.PMF
                => new PmfHistogramVisitable(),
            RndFunction.CDF
                => new CdfHistogramVisitable(),

            _   => throw new NotImplementedException(nameof(filter))
        };    
    }
}
