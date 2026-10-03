using ImageProcessing.App.Integration.Monolith.Domain.ServiceModel.VisitableFactory.BitmapLuminance.Interface;
using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Providers.Visitable.BitmapLuminance;
using ImageProcessing.App.Domain.Providers.VisitableFactory.BitmapLuminance.Implementation;

namespace ImageProcessing.App.Integration.Monolith.Domain.ServiceModel.VisitableFactory.BitmapLuminance.Implementation
{
    internal class BitmapLuminanceVisitableFactoryWrapper : IBitmapLuminanceVisitableFactoryWrapper
    {
        private readonly BitmapLuminanceVisitableFactory _factory
            = new BitmapLuminanceVisitableFactory();

        public virtual IBitmapLuminanceVisitable Get(RndInfo model)
            => _factory.Get(model);
    }
}
