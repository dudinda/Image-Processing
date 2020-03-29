using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.DomainModel.Factory.RgbFilters.Rgb.Interface;
using ImageProcessing.DomainModel.Model.RgbFilters.Implementation.Binary;
using ImageProcessing.DomainModel.Model.RgbFilters.Implementation.Grayscale;
using ImageProcessing.DomainModel.Model.RgbFilters.Implementation.Inversion;

using NSubstitute;
using NSubstitute.ExceptionExtensions;

using NUnit.Framework;

namespace ImageProcessing.DomainModel.UnitTests.Factory.Rgb
{
    [TestFixture]
    internal sealed class RgbFilterFactoryTests
    {
        private IRgbFilterFactory _rgbFilterFactory;

        [SetUp]
        public void SetUp()
        {
            _rgbFilterFactory = Substitute.For<IRgbFilterFactory>();
        }

        [Test]
        public void FactoryReturnsBinaryFilterByEnum()
        {
            _rgbFilterFactory
                .Get(RgbFilter.Binary)
                .Returns(_ => new BinaryFilter());

            Assert.That(
                _rgbFilterFactory.Get(
                    RgbFilter.Binary
                ), Is.TypeOf(typeof(BinaryFilter))
            );
        }

        [Test]
        public void FactoryReturnsGrayscaleFilterByEnum()
        {
            _rgbFilterFactory
                .Get(RgbFilter.Grayscale)
                .Returns(_ => new GrayscaleFilter());

            Assert.That(
                _rgbFilterFactory.Get(
                    RgbFilter.Grayscale
                ), Is.TypeOf(typeof(GrayscaleFilter))
            );
        }

        [Test]
        public void FactoryReturnsInversionFilterByEnum()
        {
            _rgbFilterFactory
                .Get(RgbFilter.Inversion)
                .Returns(_ => new InversionFilter());

            Assert.That(
                _rgbFilterFactory.Get(
                    RgbFilter.Inversion
                ), Is.TypeOf(typeof(InversionFilter))
            );
        }

        [Test]
        public void FactoryThrowsNotImplementedExceptionOnUnknownEnum()
        {
           _rgbFilterFactory
                .Get(RgbFilter.Unknown)
                .Throws(new NotImplementedException());

            Assert.Throws<NotImplementedException>(
                () => _rgbFilterFactory.Get(RgbFilter.Unknown)
            );
        }
    }
}
