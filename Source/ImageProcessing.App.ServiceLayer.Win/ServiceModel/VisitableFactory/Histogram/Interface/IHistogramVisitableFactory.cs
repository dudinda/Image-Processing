using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.Histogram;
using ImageProcessing.Microkernel.MVP.Model;

namespace ImageProcessing.App.ServiceLayer.ServiceModel.VisitableFactory.Histogram.Interface
{
    public interface IHistogramVisitableFactory
        : IModelFactory<IHistogramVisitable, RndFunction>
    {

    }
}
