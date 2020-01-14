using System;
using System.Drawing;

using ImageProcessing.Services.DistributionServices.Distribution.Interface;

using NSubstitute;

using NUnit.Framework;

namespace ImageProcessing.Tests.Services
{
    [TestFixture]
    internal class RandomVariableDistributionServiceTests
    {
        private IRandomVariableDistributionService _distributionService;
        private Image _image;
        
        [SetUp]
        public void SetUp()
        {
            _distributionService = Substitute.For<IRandomVariableDistributionService>();
            _image = Substitute.For<Image>();
        }

        [Test]
        public void ServiceGetCDFThrowsArgumentNullExceptionIfPmfArrayIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => _distributionService.GetCDF(null));
        }

        [Test]
        public void ServiceGetVarianceThrowsArgumentNullExceptionIfPmfArrayIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => _distributionService.GetVariance(null));
        }


        [Test]
        public void ServiceGetPMFThrowsArgumentNullExceptionIfFrequenciesArrayIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => _distributionService.GetPMF(null));
        }

        [Test]
        public void ServiceGetVarianceReturnsNonNegativeValue()
        {
            var pmf = new decimal[] { 0.1M, 0.2M, 0.3M, 0.4M };

            Assert.That(() => _distributionService.GetVariance(pmf) >= 0);
        }

        [Test]
        public void ServiceThrowsIfPmfIsNotNormalized()
        {
            var pmf = new decimal[] { 0.1M, 0.201M, 0.3M, 0.4M };

            Assert.Throws<ArgumentException>(() => _distributionService.GetVariance(pmf));
        }


    }
}
