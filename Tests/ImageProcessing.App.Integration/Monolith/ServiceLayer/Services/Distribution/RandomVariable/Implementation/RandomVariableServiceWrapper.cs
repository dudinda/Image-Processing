using ImageProcessing.App.DomainLayer.DomainModel.Distribution.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Distribution.RandomVariable.Interface;
using ImageProcessing.App.ServiceLayer.Services.Distribution.RandomVariable.Interface;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Distribution.RandomVariable.Implementation
{
    internal class RandomVariableServiceWrapper : IRandomVariableServiceWrapper
    {
        private readonly IRandomVariableDistributionService _service;

        public RandomVariableServiceWrapper(IRandomVariableDistributionService service)
        {
            _service = service;
        }

        public virtual decimal[] GetCDF(decimal[] pmf)
            => _service.GetCDF(pmf);

        public virtual decimal GetConditionalExpectation((int x1, int x2) interval, decimal[] pmf)
            => _service.GetConditionalExpectation(interval, pmf);

        public virtual decimal GetConditionalVariance((int x1, int x2) interval, decimal[] pmf)
            => _service.GetConditionalVariance(interval, pmf);

        public virtual decimal GetEntropy(decimal[] pmf)
            => _service.GetEntropy(pmf);

        public virtual decimal GetExpectation(decimal[] pmf)
            => _service.GetExpectation(pmf);

        public virtual decimal[] GetPMF(int[] frequencies)
            => _service.GetPMF(frequencies);

        public virtual decimal GetStandardDeviation(decimal[] pmf)
            => _service.GetStandardDeviation(pmf);

        public virtual decimal GetVariance(decimal[] pmf)
            => _service.GetVariance(pmf);

        public byte[] TransformToByte(decimal[] cdf, IDistribution distribution)
            => _service.TransformToByte(cdf, distribution);

        public decimal[] TransformToDecimal(decimal[] cdf, IDistribution distribution)
            => _service.TransformToDecimal(cdf, distribution);
    }
}
