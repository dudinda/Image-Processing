using System.Drawing;

using ImageProcessing.App.ServiceLayer.ServiceModel.Visitors.BitmapLuminance.Interface;
using ImageProcessing.App.ServiceLayer.Services.Distribution.BitmapLuminance.Interface;

namespace ImageProcessing.App.ServiceLayer.ServiceModel.Visitors.BitmapLuminance.Implementation
{
    public sealed class BitmapLuminanceVisitor : IBitmapLuminanceVisitor
    {
        private IBitmapLuminanceService _service;

        public BitmapLuminanceVisitor(IBitmapLuminanceService service)
        {
            _service = service;
        }

        public decimal GetStandardDeviation(Bitmap bmp)
            => _service.GetStandardDeviation(bmp);

        public decimal GetEntropy(Bitmap bmp)
            => _service.GetEntropy(bmp);

        public decimal GetExpectation(Bitmap bmp)
            => _service.GetExpectation(bmp);

        public decimal GetVariance(Bitmap bmp)
            => _service.GetVariance(bmp);
    }
}
