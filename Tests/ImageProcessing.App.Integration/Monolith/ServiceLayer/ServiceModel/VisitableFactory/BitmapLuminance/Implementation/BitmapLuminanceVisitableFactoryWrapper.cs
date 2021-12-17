using ImageProcessing.App.Integration.Monolith.ServiceLayer.ServiceModel.VisitableFactory.BitmapLuminance.Interface;
using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitable.BitmapLuminance;
using ImageProcessing.App.ServiceLayer.ServiceModel.VisitableFactory.BitmapLuminance.Implementation;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.ServiceModel.VisitableFactory.BitmapLuminance.Implementation
{
    internal class BitmapLuminanceVisitableFactoryWrapper : IBitmapLuminanceVisitableFactoryWrapper
    {
        private readonly BitmapLuminanceVisitableFactory _factory
            = new BitmapLuminanceVisitableFactory();

        public virtual IBitmapLuminanceVisitable Get(RndInfo model)
            => _factory.Get(model);
    }
}
