using ImageProcessing.App.Integration.Monolith.Domain.ServiceModel.VisitableFactory.Histogram.Interface;
using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Win.Providers.Visitable.Histogram;
using ImageProcessing.App.Domain.Win.Providers.VisitableFactory.Histogram.Implementation;

namespace ImageProcessing.App.Integration.Monolith.Domain.ServiceModel.VisitableFactory.Histogram.Implementation
{
    internal class HistogramVisitableFactoryWrapper : IHistogramVisitableFactoryWrapper
    {
        private readonly HistogramVisitableFactory _factory
            = new HistogramVisitableFactory();

        public virtual IHistogramVisitable Get(RndFunction model)
            => _factory.Get(model);
    }
}
