using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Factories;
using ImageProcessing.App.Domain.Providers.Visitable.BitmapLuminance;

namespace ImageProcessing.App.Domain.Providers.VisitableFactory.BitmapLuminance
{
    public interface IBitmapLuminanceVisitableFactory
        : IModelFactory<IBitmapLuminanceVisitable, RndInfo>
    {

    }
}
