using System;

using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.UnitTests.CaseFactory;
using ImageProcessing.App.ServiceLayer.Models.AppSettings;
using ImageProcessing.App.ServiceLayer.Services.Factories.Recommendation;
using ImageProcessing.App.ServiceLayer.Services.Factories.Rgb;
using ImageProcessing.App.ServiceLayer.Services.Factories.Rgb.Implementation;

using NSubstitute;

using NUnit.Framework;

using static ImageProcessing.App.ServiceLayer.UnitTests.CaseFactory.ServiceLayerFactoriesCaseFactory;

namespace ImageProcessing.App.ServiceLayer.UnitTests.Factory.Rgb
{
    [TestFixture]
    internal sealed class RgbFilterFactoryTests
    {
        private IRgbFilterFactory _rgbFilterFactory;

        [SetUp]
        public void SetUp()
        {
            _rgbFilterFactory = new RgbFilterFactory(
                Substitute.For<IRecommendationFactory>(),
                Substitute.For<IChannelFactory>(),
                Substitute.For<AppSettings>()
            );
        }

        [Test, TestCaseSource(
               typeof(ServiceLayerFactoriesCaseFactory),
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
