using ImageProcessing.App.DomainLayer.Factories;
using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Win.Providers.Visitable.Histogram;

namespace ImageProcessing.App.ServiceLayer.Win.Providers.VisitableFactory.Histogram
{
    public interface IHistogramVisitableFactory
        : IModelFactory<IHistogramVisitable, RndFunction>
    {

    }
}
