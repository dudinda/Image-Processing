using ImageProcessing.Common.Enums;
using ImageProcessing.DomainModel.Factory.RgbFilters.Color.Interface;
using ImageProcessing.DomainModel.Model.RgbFilters.Implementation.Color.Colors;
using NSubstitute;

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
            Assert.IsTrue(_colorFactory.Get(RgbColors.Red) is RColor);
        }

        [Test]
        public void FactoryReturnsBlueColorOnBCombination()
        {
            Assert.IsTrue(_colorFactory.Get(RgbColors.Blue) is BColor);
        }
    }
}
