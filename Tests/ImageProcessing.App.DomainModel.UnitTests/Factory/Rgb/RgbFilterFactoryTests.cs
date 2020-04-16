using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainModel.Factory.RgbFilters.Color.Interface;
using ImageProcessing.App.DomainModel.Factory.RgbFilters.Rgb.Implementation;
using ImageProcessing.App.DomainModel.Factory.RgbFilters.Rgb.Interface;
using ImageProcessing.App.DomainModel.Model.RgbFilters.Implementation.Binary;
using ImageProcessing.App.DomainModel.Model.RgbFilters.Implementation.Grayscale;
using ImageProcessing.App.DomainModel.Model.RgbFilters.Implementation.Inversion;

using NSubstitute;

using NUnit.Framework;

namespace ImageProcessing.App.DomainModel.UnitTests.Factory.Rgb
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
