using System;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Win.Providers.Visitable.Histogram;
using ImageProcessing.App.Domain.Win.Providers.Visitable.Histogram.Implementation;

namespace ImageProcessing.App.Domain.Win.Providers.VisitableFactory.Histogram.Implementation
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
