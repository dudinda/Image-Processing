using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.Factory.RgbFilters.Color.Interface;
using ImageProcessing.App.DomainLayer.Factory.RgbFilters.Rgb.Implementation;
using ImageProcessing.App.DomainLayer.Factory.RgbFilters.Rgb.Interface;
using ImageProcessing.App.DomainLayer.UnitTests.CaseFactory;

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
                Substitute.For<IColorFactory>()
            );
        }

        [Test, TestCaseSource(
               typeof(DomainLayerFactoriesCaseFactory),
               nameof(RgbFiltersFactoryTestCases))]
        public void FactoryReturnsBinaryFilterByEnum((RgbFilter Input, Type Result) args)
            =>  Assert.That(_rgbFilterFactory.Get(args.Input), Is.TypeOf(args.Result));

        [Test]
        public void FactoryThrowsNotImplementedExceptionOnUnknownEnum()
            => Assert.Throws<NotImplementedException>(
                () => _rgbFilterFactory.Get(RgbFilter.Unknown)
            );
    }
}
