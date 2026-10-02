using System;

using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Factories.Distribution.Implementation;
using ImageProcessing.App.ServiceLayer.UnitTests.CaseFactory;
using ImageProcessing.App.ServiceLayer.Services.Factories.Distribution;

using NUnit.Framework;

using static ImageProcessing.App.ServiceLayer.UnitTests.CaseFactory.ServiceLayerFactoriesCaseFactory;

namespace ImageProcessing.App.ServiceLayer.UnitTests.Factory.Distribution
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
               typeof(ServiceLayerFactoriesCaseFactory),
               nameof(DistributionFactoryTestCases))]
        public void FactoryReturnsRayleighByEnumValue((PrDistribution Input, Type Result) args)
            => Assert.That(_distributionFactory.Get(args.Input), Is.TypeOf(args.Result));

        [Test]
        public void FactoryThrowsNotImplementedExceptionOnUnknownEnum()
            => Assert.Throws<NotImplementedException>(
                () => _distributionFactory.Get(PrDistribution.Unknown)
            );       
    }
}
