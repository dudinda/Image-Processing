using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.DomainModel.Factory.RgbFilters.Rgb.Interface;
using ImageProcessing.DomainModel.Model.RgbFilters.Implementation.Binary;
using ImageProcessing.DomainModel.Model.RgbFilters.Implementation.Grayscale;
using ImageProcessing.DomainModel.Model.RgbFilters.Implementation.Inversion;

using NSubstitute;

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
        public void FactoryReturnsBinaryFilterOnBinaryEnum()
        {
            Assert.IsTrue(_rgbFilterFactory.Get(RgbFilter.Binary) is BinaryFilter);
        }

        [Test]
        public void FactoryReturnsBinaryFilterOnGrayscaleEnum()
        {
            Assert.IsTrue(_rgbFilterFactory.Get(RgbFilter.Grayscale) is GrayscaleFilter);
        }

        [Test]
        public void FactoryReturnsBinaryFilterOnInversionEnum()
        {
            Assert.IsTrue(_rgbFilterFactory.Get(RgbFilter.Inversion) is InversionFilter);
        }

        [Test]
        public void FactoryThrowsNotImplementedExceptionOnUnknownEnum()
        {
            Assert.Throws<NotImplementedException>(() => _rgbFilterFactory.Get(RgbFilter.Unknown));
        }
    }
}
