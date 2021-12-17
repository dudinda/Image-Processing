using ImageProcessing.App.Integration.Monolith.ServiceLayer.ServiceModel.VisitableFactory.Histogram.Interface;
using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Win.ServiceModel.Visitable.Histogram;
using ImageProcessing.App.ServiceLayer.Win.ServiceModel.VisitableFactory.Histogram.Implementation;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.ServiceModel.VisitableFactory.Histogram.Implementation
{
    internal class HistogramVisitableFactoryWrapper : IHistogramVisitableFactoryWrapper
    {
        private readonly HistogramVisitableFactory _factory
            = new HistogramVisitableFactory();

        public virtual IHistogramVisitable Get(RndFunction model)
            => _factory.Get(model);
    }
}
