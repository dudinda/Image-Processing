using System;
using System.Drawing;

using ImageProcessing.App.Integration.Monolith.ServiceLayer.ServiceModel.Vistiors.BitmapLuminance.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Distribution.BitmapLuminance.Interface;
using ImageProcessing.App.ServiceLayer.Services.Distribution.BitmapLuminance.Implementation;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.ServiceModel.Vistiors.BitmapLuminance.Implementation
{
    internal class BitmapLuminanceVisitorWrapper : IBitmapLuminanceVisitorWrapper
    {
        private readonly BitmapLuminanceService _service;

        public BitmapLuminanceVisitorWrapper(
            IBitmapLuminanceServiceWrapper service)
        {

        }

        public decimal GetEntropy(Bitmap bmp)
        {
            throw new NotImplementedException();
        }

        public decimal GetExpectation(Bitmap bmp)
        {
            throw new NotImplementedException();
        }

        public decimal GetStandardDeviation(Bitmap bmp)
        {
            throw new NotImplementedException();
        }

        public decimal GetVariance(Bitmap bmp)
        {
            throw new NotImplementedException();
        }
    }
}
