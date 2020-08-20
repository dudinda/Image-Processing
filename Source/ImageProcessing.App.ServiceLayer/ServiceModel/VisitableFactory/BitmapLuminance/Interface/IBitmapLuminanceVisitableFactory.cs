using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.BitmapLuminance;
using ImageProcessing.Microkernel.MVP.Model;

namespace ImageProcessing.App.ServiceLayer.ServiceModel.VisitableFactory.BitmapLuminance.Interface
{
    internal interface IBitmapLuminanceVisitableFactory
        : IModelFactory<IBitmapLuminanceVisitable, RandomVariableInfo>
    {

    }
}
