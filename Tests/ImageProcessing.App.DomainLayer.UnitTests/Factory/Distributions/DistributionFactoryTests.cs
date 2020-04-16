using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.Factory.Distributions.Implementation;
using ImageProcessing.App.DomainLayer.Factory.Distributions.Interface;
using ImageProcessing.App.DomainLayer.Model.Distributions.Implementation.OneParameter;
using ImageProcessing.App.DomainLayer.Model.Distributions.Implementation.TwoParameter;

using NUnit.Framework;

namespace ImageProcessing.App.DomainLayer.UnitTests.Factory.Distributions
{
    [TestFixture]
    internal sealed class DistributionFactoryTests
    {
        private IDistributionFactory _distributionFactory;

        [SetUp]
        public void SetUp()
        {
            _distributionFactory = new DistributionFactory();
        }

        [Test]
        public void FactoryReturnsRayleighByEnumValue()
        {
            Assert.That(
                _distributionFactory.Get(
                    Distribution.Rayleigh
                ), Is.TypeOf(typeof(RayleighDistribution))
            );
        }

        [Test]
        public void FactoryReturnsExponentialByEnumValue()
        {
            Assert.That(
                _distributionFactory.Get(
                    Distribution.Exponential
                ), Is.TypeOf(typeof(ExponentialDistribution))
            );
        }

        [Test]
        public void FactoryReturnsCauchyByEnumValue()
        {
            Assert.That(
                _distributionFactory.Get(
                    Distribution.Cauchy
                ), Is.TypeOf(typeof(CauchyDistribution))
            );
        }

        [Test]
        public void FactoryReturnsLaplaceByEnumValue()
        {
            Assert.That(
                _distributionFactory.Get(
                    Distribution.Laplace
                ), Is.TypeOf(typeof(LaplaceDistribution))
            );
        }

        [Test]
        public void FactoryReturnsNormalByEnumValue()
        {
            Assert.That(
                _distributionFactory.Get(
                    Distribution.Normal
                ), Is.TypeOf(typeof(NormalDistribution))
            );
        }

        [Test]
        public void FactoryReturnsParabolaByEnumValue()
        {
            Assert.That(
                _distributionFactory.Get(
                    Distribution.Parabola
                ), Is.TypeOf(typeof(ParabolaDistribution))
            );
        }

        [Test]
        public void FactoryReturnsUniformByEnumValue()
        {
            Assert.That(
                _distributionFactory.Get(
                    Distribution.Uniform
                ), Is.TypeOf(typeof(UniformDistribution))
            );
        }

        [Test]
        public void FactoryReturnsWeibullByEnumValue()
        {
            Assert.That(
                _distributionFactory.Get(
                    Distribution.Weibull
                ), Is.TypeOf(typeof(WeibullDistribution))
            );
        }
    }
}
