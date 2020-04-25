using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.Factory.RgbFilters.Color.Implementation;
using ImageProcessing.App.DomainLayer.Factory.RgbFilters.Color.Interface;
using ImageProcessing.App.DomainLayer.UnitTests.CaseFactory;

using NUnit.Framework;

using static ImageProcessing.App.DomainLayer.UnitTests.CaseFactory.DomainLayerFactoriesCaseFactory;

namespace ImageProcessing.App.DomainLayer.UnitTests.Factory.Color
{
    [TestFixture]
    internal sealed class ColorRgbFilterFactoryTests
    {
        private IColorFactory _colorFactory;

        [SetUp]
        public void SetUp()
        {
            _colorFactory = new ColorFactory();
        }

        [Test, TestCaseSource(
            typeof(DomainLayerFactoriesCaseFactory),
            nameof(ColorFactoryTestCases))]
        public void FactoryReturnsRedColorOnRCombination(RgbColors color, Type returnType)
            => Assert.That(_colorFactory.Get(color), Is.TypeOf(returnType));

        [Test]
        public void FactoryThrowsNotImplementedExceptionOnUnknownEnum()
            => Assert.Throws<NotSupportedException>(
                () => _colorFactory.Get(RgbColors.Unknown)
            );
    }
}
