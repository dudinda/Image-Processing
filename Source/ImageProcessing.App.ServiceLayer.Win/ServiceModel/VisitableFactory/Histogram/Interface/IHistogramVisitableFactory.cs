using ImageProcessing.App.DomainLayer.DomainFactory;
using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.Histogram;

namespace ImageProcessing.App.ServiceLayer.ServiceModel.VisitableFactory.Histogram.Interface
{
    public interface IHistogramVisitableFactory
        : IModelFactory<IHistogramVisitable, RndFunction>
    {

    }
}
