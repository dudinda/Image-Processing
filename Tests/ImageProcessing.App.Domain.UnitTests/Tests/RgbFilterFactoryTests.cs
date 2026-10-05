using System;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Models.Options;
using ImageProcessing.App.Domain.Models.Recommendation.Implementation;
using ImageProcessing.App.Domain.Services.Factories.Recommendation;
using ImageProcessing.App.Domain.Services.Factories.Rgb;
using ImageProcessing.App.Domain.Services.Factories.Rgb.Implementation;
using ImageProcessing.App.Domain.UnitTests.CaseFactory;

using NSubstitute;

using NUnit.Framework;

using static ImageProcessing.App.Domain.UnitTests.CaseFactory.DomainFactoriesCaseFactory;

namespace ImageProcessing.App.Domain.UnitTests.Factory.Rgb
{
    [TestFixture]
    internal sealed class RgbFilterFactoryTests
    {
        private IRgbFilterFactory _rgbFilterFactory;

        [SetUp]
        public void SetUp()
        {
            var recommendation = Substitute.For<IRecommendationFactory>();
            recommendation.Get(Arg.Any<Luma>()).Returns(new Rec601());
            _rgbFilterFactory = new RgbFilterFactory(
                recommendation,
                Substitute.For<IChannelFactory>(),
                Substitute.For<AppOptions>()
            );
        }

        [Test, TestCaseSource(
               typeof(DomainFactoriesCaseFactory),
               nameof(RgbFiltersFactoryTestCases))]
        public void FactoryReturnsBinaryFilterByEnum((RgbFltr Input, Type Result) args)
            =>  Assert.That(_rgbFilterFactory.Get(args.Input), Is.TypeOf(args.Result));

        [Test]
        public void FactoryThrowsNotImplementedExceptionOnUnknownEnum()
            => Assert.Throws<NotImplementedException>(
                () => _rgbFilterFactory.Get(RgbFltr.Unknown)
            );
    }
}
