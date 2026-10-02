using ImageProcessing.App.ServiceLayer.Factories;
using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Providers.Visitable.BitmapLuminance;

namespace ImageProcessing.App.ServiceLayer.Providers.VisitableFactory.BitmapLuminance
{
    public interface IBitmapLuminanceVisitableFactory
        : IModelFactory<IBitmapLuminanceVisitable, RndInfo>
    {

    }
}
