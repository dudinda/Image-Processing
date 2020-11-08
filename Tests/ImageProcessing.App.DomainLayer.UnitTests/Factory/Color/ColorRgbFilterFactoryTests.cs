using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.Color.Implementation;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.Color.Interface;
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
        public void FactoryReturnsRedColorOnRCombination((RgbColors Input, Type Return) args)
            => Assert.That(_colorFactory.Get(args.Input), Is.TypeOf(args.Return));

        [Test]
        public void FactoryThrowsNotImplementedExceptionOnUnknownEnum()
            => Assert.Throws<NotSupportedException>(
                () => _colorFactory.Get(RgbColors.Unknown)
            );
    }
}
