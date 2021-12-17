
using System.Drawing;

using ImageProcessing.App.DomainLayer.DomainModel.Distribution.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Distribution.BitmapLuminance.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Distribution.RandomVariable.Interface;
using ImageProcessing.App.ServiceLayer.Services.Distribution.BitmapLuminance.Implementation;
using ImageProcessing.App.ServiceLayer.Services.Distribution.BitmapLuminance.Interface;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Distribution.BitmapLuminance.Implementation
{
    internal class BitmapLuminanceServiceWrapper : IBitmapLuminanceServiceWrapper
    {
        private readonly BitmapLuminanceService _service;

        public IRandomVariableServiceWrapper RandomVariable { get; }

        public BitmapLuminanceServiceWrapper(
            IRandomVariableServiceWrapper rnd)
        {
            RandomVariable = rnd;
            _service = new BitmapLuminanceService(rnd);
        }

        public virtual decimal[] GetCDF(Bitmap bitmap)
            => _service.GetCDF(bitmap);

        public virtual decimal GetConditionalExpectation((int x1, int x2) interval, Bitmap bitmap)
            => _service.GetConditionalExpectation(interval, bitmap);

        public virtual decimal GetConditionalVariance((int x1, int x2) interval, Bitmap bitmap)
            => _service.GetConditionalVariance(interval, bitmap);

        public virtual decimal GetEntropy(Bitmap bitmap)
            => _service.GetEntropy(bitmap);

        public virtual decimal GetExpectation(Bitmap bitmap)
            => _service.GetExpectation(bitmap);

        public virtual int[] GetFrequencies(Bitmap bitmap)
            => _service.GetFrequencies(bitmap);

        public virtual decimal[] GetPMF(Bitmap bitmap)
            => _service.GetPMF(bitmap);

        public virtual decimal GetStandardDeviation(Bitmap bitmap)
            => _service.GetStandardDeviation(bitmap);

        public virtual decimal GetVariance(Bitmap bitmap)
            => _service.GetVariance(bitmap);

        public virtual Bitmap Transform(Bitmap bitmap, IDistribution distribution)
            => _service.Transform(bitmap, distribution);
    }
}
