using ImageProcessing.App.DomainLayer.Factories;
using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.BitmapLuminance;

namespace ImageProcessing.App.ServiceLayer.ServiceModel.VisitableFactory.BitmapLuminance.Interface
{
    public interface IBitmapLuminanceVisitableFactory
        : IModelFactory<IBitmapLuminanceVisitable, RndInfo>
    {

    }
}
