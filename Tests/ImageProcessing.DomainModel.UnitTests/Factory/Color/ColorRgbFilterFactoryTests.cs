using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.DomainModel.Factory.RgbFilters.Color.Interface;
using ImageProcessing.DomainModel.Model.RgbFilters.Implementation.Color.Colors;

using NSubstitute;
using NSubstitute.ExceptionExtensions;

using NUnit.Framework;

namespace ImageProcessing.DomainModel.UnitTests.Factory.Color
{
    [TestFixture]
    internal sealed class ColorRgbFilterFactoryTests
    {
        private IColorFactory _colorFactory;

        [SetUp]
        public void SetUp()
        {
            _colorFactory = Substitute.For<IColorFactory>();
        }

        [Test]
        public void FactoryReturnsRedColorOnRCombination()
        {
            _colorFactory.Get(
                RgbColors.Red
            ).Returns(_ => new RColor());

            Assert.That(
                _colorFactory.Get(
                    RgbColors.Red
                ), Is.TypeOf(typeof(RColor))
            );
        }

        [Test]
        public void FactoryReturnsBlueColorOnBCombination()
        {
            _colorFactory.Get(
                 RgbColors.Blue
             ).Returns(_ => new BColor());

            Assert.That(
                _colorFactory.Get(
                    RgbColors.Blue
                ), Is.TypeOf(typeof(BColor))
            );
        }

        [Test]
        public void FactoryReturnsGreenColorOnBCombination()
        {
            _colorFactory.Get(
                RgbColors.Green
            ).Returns(_ => new GColor());

            Assert.That(
                _colorFactory.Get(
                   RgbColors.Green
                ), Is.TypeOf(typeof(GColor))
            );
        }

        [Test]
        public void FactoryReturnsRedGreenColorOnRGCombination()
        {
            _colorFactory.Get(
                 RgbColors.Green | RgbColors.Red
             ).Returns(_ => new RGColor());

            Assert.That(
                _colorFactory.Get(
                    RgbColors.Green | RgbColors.Red
                ), Is.TypeOf(typeof(RGColor))
            );
        }

        [Test]
        public void FactoryReturnsRedBlueColorOnRBCombination()
        {
            _colorFactory.Get(
                RgbColors.Blue | RgbColors.Red
            ).Returns(_ => new RBColor());

            Assert.That(
                _colorFactory.Get(
                    RgbColors.Blue | RgbColors.Red
                ), Is.TypeOf(typeof(RBColor))
            );
        }

        [Test]
        public void FactoryReturnsBlueGreenColorOnBGCombination()
        {
            _colorFactory.Get(
                 RgbColors.Blue | RgbColors.Green 
             ).Returns(_ => new BGColor());

            Assert.That(
                _colorFactory.Get(
                    RgbColors.Blue | RgbColors.Green 
                ), Is.TypeOf(typeof(BGColor))
            );
        }

        [Test]
        public void FactoryReturnsRedGreenBlueColorOnRGBCombination()
        {
            _colorFactory.Get(
                RgbColors.Blue | RgbColors.Green | RgbColors.Red
            ).Returns(_ => new RGBColor());

            Assert.That(
                _colorFactory.Get(
                    RgbColors.Blue | RgbColors.Green | RgbColors.Red
                ), Is.TypeOf(typeof(RGBColor))
            );
        }

        [Test]
        public void FactoryThrowsNotImplementedExceptionOnUnknownEnum()
        {
            _colorFactory
                .Get(RgbColors.Unknown)
                .Throws(new NotImplementedException());

            Assert.Throws<NotImplementedException>(
                () => _colorFactory.Get(RgbColors.Unknown)
            );
        }
    }
}
