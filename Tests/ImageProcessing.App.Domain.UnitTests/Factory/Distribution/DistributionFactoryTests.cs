using System;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Factories.Distribution.Implementation;
using ImageProcessing.App.Domain.UnitTests.CaseFactory;
using ImageProcessing.App.Domain.Services.Factories.Distribution;

using NUnit.Framework;

using static ImageProcessing.App.Domain.UnitTests.CaseFactory.DomainFactoriesCaseFactory;

namespace ImageProcessing.App.Domain.UnitTests.Factory.Distribution
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
               typeof(DomainFactoriesCaseFactory),
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
