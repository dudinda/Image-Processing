using System.Drawing;

using ImageProcessing.App.Integration.Monolith.ServiceLayer.ServiceModel.Vistiors.BitmapLuminance.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Distribution.BitmapLuminance.Interface;
using ImageProcessing.App.ServiceLayer.ServiceModel.Visitors.BitmapLuminance.Implementation;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.ServiceModel.Vistiors.BitmapLuminance.Implementation
{
    internal class BitmapLuminanceVisitorWrapper : IBitmapLuminanceVisitorWrapper
    {
        private readonly BitmapLuminanceVisitor _visitor;

        public IBitmapLuminanceServiceWrapper BitmapLuminance { get; }

        public BitmapLuminanceVisitorWrapper(
            IBitmapLuminanceServiceWrapper service)
        {
            BitmapLuminance = service;
            _visitor = new BitmapLuminanceVisitor(service);
        }

        public virtual decimal GetEntropy(Bitmap bmp)
            => _visitor.GetEntropy(bmp);

        public virtual decimal GetExpectation(Bitmap bmp)
            => _visitor.GetExpectation(bmp);

        public virtual decimal GetStandardDeviation(Bitmap bmp)
            => _visitor.GetStandardDeviation(bmp);

        public virtual decimal GetVariance(Bitmap bmp)
            => _visitor.GetVariance(bmp);
    }
}
