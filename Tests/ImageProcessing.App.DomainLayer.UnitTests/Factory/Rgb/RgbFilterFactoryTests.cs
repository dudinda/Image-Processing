using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.Factory.RgbFilters.Color.Interface;
using ImageProcessing.App.DomainLayer.Factory.RgbFilters.Rgb.Implementation;
using ImageProcessing.App.DomainLayer.Factory.RgbFilters.Rgb.Interface;
using ImageProcessing.App.DomainLayer.Model.RgbFilters.Implementation.Binary;
using ImageProcessing.App.DomainLayer.Model.RgbFilters.Implementation.Grayscale;
using ImageProcessing.App.DomainLayer.Model.RgbFilters.Implementation.Inversion;

using NSubstitute;

using NUnit.Framework;

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

        [Test]
        public void FactoryReturnsBinaryFilterByEnum()
        {
            Assert.That(
                _rgbFilterFactory.Get(
                    RgbFilter.Binary
                ), Is.TypeOf(typeof(BinaryFilter))
            );
        }

        [Test]
        public void FactoryReturnsGrayscaleFilterByEnum()
        {
            Assert.That(
                _rgbFilterFactory.Get(
                    RgbFilter.Grayscale
                ), Is.TypeOf(typeof(GrayscaleFilter))
            );
        }

        [Test]
        public void FactoryReturnsInversionFilterByEnum()
        {
            Assert.That(
                _rgbFilterFactory.Get(
                    RgbFilter.Inversion
                ), Is.TypeOf(typeof(InversionFilter))
            );
        }

        [Test]
        public void FactoryThrowsNotImplementedExceptionOnUnknownEnum()
        {
            Assert.Throws<NotImplementedException>(
                () => _rgbFilterFactory.Get(RgbFilter.Unknown)
            );
        }
    }
}
