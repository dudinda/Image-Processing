using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Factories;
using ImageProcessing.App.Domain.Win.Providers.Visitable.Histogram;

namespace ImageProcessing.App.Domain.Win.Providers.VisitableFactory.Histogram
{
    public interface IHistogramVisitableFactory
        : IModelFactory<IHistogramVisitable, RndFunction>
    {

    }
}
