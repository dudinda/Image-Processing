using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.Factory.Distributions.Implementation;
using ImageProcessing.App.DomainLayer.Factory.Distributions.Interface;
using ImageProcessing.App.DomainLayer.Model.Distributions.Implementation.OneParameter;
using ImageProcessing.App.DomainLayer.UnitTests.CaseFactory;

using NUnit.Framework;

using static ImageProcessing.App.DomainLayer.UnitTests.CaseFactory.DomainLayerFactoriesCaseFactory;

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

        [Test, TestCaseSource(
               typeof(DomainLayerFactoriesCaseFactory),
               nameof(DistributionFactoryTestCases))]
        public void FactoryReturnsRayleighByEnumValue(Distribution distribution, Type returnType)
            => Assert.That(_distributionFactory.Get(distribution), Is.TypeOf(returnType));

        [Test]
        public void FactoryThrowsNotImplementedExceptionOnUnknownEnum()
            => Assert.Throws<NotImplementedException>(
                () => _distributionFactory.Get(Distribution.Unknown)
            );       
    }
}
