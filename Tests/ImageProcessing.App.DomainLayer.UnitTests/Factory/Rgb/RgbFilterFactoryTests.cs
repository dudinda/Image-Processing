using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.Channel.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.RgbFilter.Implementation;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.RgbFilter.Interface;
using ImageProcessing.App.DomainLayer.Factory.RgbFilters.Recommendation.Interface;
using ImageProcessing.App.DomainLayer.UnitTests.CaseFactory;
using ImageProcessing.App.ServiceLayer.Services.Settings.Interface;

using NSubstitute;

using NUnit.Framework;

using static ImageProcessing.App.DomainLayer.UnitTests.CaseFactory.DomainLayerFactoriesCaseFactory;

namespace ImageProcessing.App.DomainLayer.UnitTests.Factory.Rgb
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
                Substitute.For<IAppSettings>()
            );
        }

        [Test, TestCaseSource(
               typeof(DomainLayerFactoriesCaseFactory),
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
