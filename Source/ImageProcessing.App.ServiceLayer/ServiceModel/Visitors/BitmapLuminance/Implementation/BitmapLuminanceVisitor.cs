using System.Drawing;

using ImageProcessing.App.ServiceLayer.Services.Distributions.BitmapLuminance.Interface;
using ImageProcessing.App.ServiceLayer.Visitors.BitmapLuminance.Visitor.Interface;

namespace ImageProcessing.App.ServiceLayer.Visitors.BitmapLuminance.Visitor.Implementation
{
    internal sealed class BitmapLuminanceVisitor : IBitmapLuminanceVisitor
    {
        private IBitmapLuminanceDistributionService _service;

        public BitmapLuminanceVisitor(IBitmapLuminanceDistributionService service)
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
