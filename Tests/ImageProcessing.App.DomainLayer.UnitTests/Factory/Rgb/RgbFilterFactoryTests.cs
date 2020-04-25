using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.Factory.RgbFilters.Color.Interface;
using ImageProcessing.App.DomainLayer.Factory.RgbFilters.Rgb.Implementation;
using ImageProcessing.App.DomainLayer.Factory.RgbFilters.Rgb.Interface;
using ImageProcessing.App.DomainLayer.Model.RgbFilters.Implementation.Binary;
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
        public void FactoryReturnsBinaryFilterByEnum(RgbFilter filter, Type returnType)
            =>  Assert.That(_rgbFilterFactory.Get(filter), Is.TypeOf(returnType));

        [Test]
        public void FactoryThrowsNotImplementedExceptionOnUnknownEnum()
            => Assert.Throws<NotImplementedException>(
                () => _rgbFilterFactory.Get(RgbFilter.Unknown)
            );
    }
}
