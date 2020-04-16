using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.Factory.RgbFilters.Color.Implementation;
using ImageProcessing.App.DomainLayer.Factory.RgbFilters.Color.Interface;
using ImageProcessing.App.DomainLayer.Model.RgbFilters.Interface.Color;
using ImageProcessing.App.DomainLayer.Model.RgbFilters.Implementation.Color.Colors;

using NUnit.Framework;

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

        [Test]
        public void FactoryReturnsRedColorOnRCombination()
        {
            Assert.That(
                _colorFactory.Get(
                    RgbColors.Red
                ), Is.TypeOf(typeof(RColor))
            );
        }

        [Test]
        public void FactoryReturnsBlueColorOnBCombination()
        {
            Assert.That(
                _colorFactory.Get(
                    RgbColors.Blue
                ), Is.TypeOf(typeof(IColor))
            );
        }

        [Test]
        public void FactoryReturnsGreenColorOnBCombination()
        {
            Assert.That(
                _colorFactory.Get(
                   RgbColors.Green
                ), Is.TypeOf(typeof(GColor))
            );
        }

        [Test]
        public void FactoryReturnsRedGreenColorOnRGCombination()
        {
            Assert.That(
                _colorFactory.Get(
                    RgbColors.Green | RgbColors.Red
                ), Is.TypeOf(typeof(RGColor))
            );
        }

        [Test]
        public void FactoryReturnsRedBlueColorOnRBCombination()
        {
            Assert.That(
                _colorFactory.Get(
                    RgbColors.Blue | RgbColors.Red
                ), Is.TypeOf(typeof(RBColor))
            );
        }

        [Test]
        public void FactoryReturnsBlueGreenColorOnBGCombination()
        {
            Assert.That(
                _colorFactory.Get(
                    RgbColors.Blue | RgbColors.Green 
                ), Is.TypeOf(typeof(BGColor))
            );
        }

        [Test]
        public void FactoryReturnsRedGreenBlueColorOnRGBCombination()
        {
            Assert.That(
                _colorFactory.Get(
                    RgbColors.Blue | RgbColors.Green | RgbColors.Red
                ), Is.TypeOf(typeof(RGBColor))
            );
        }

        [Test]
        public void FactoryThrowsNotImplementedExceptionOnUnknownEnum()
        {
            Assert.Throws<NotImplementedException>(
                () => _colorFactory.Get(RgbColors.Unknown)
            );
        }
    }
}
