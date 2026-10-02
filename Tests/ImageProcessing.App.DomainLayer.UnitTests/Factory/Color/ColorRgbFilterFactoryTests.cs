using System;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.UnitTests.CaseFactory;
using ImageProcessing.App.ServiceLayer.Services.Factories.Rgb;
using ImageProcessing.App.ServiceLayer.Services.Factories.Rgb.Implementation;

using NUnit.Framework;

using static ImageProcessing.App.DomainLayer.UnitTests.CaseFactory.DomainLayerFactoriesCaseFactory;

namespace ImageProcessing.App.DomainLayer.UnitTests.Factory.Color
{
    [TestFixture]
    internal sealed class ColorRgbFilterFactoryTests
    {
        private IChannelFactory _colorFactory;

        [SetUp]
        public void SetUp()
        {
            _colorFactory = new ChannelFactory();
        }

        [Test, TestCaseSource(
            typeof(DomainLayerFactoriesCaseFactory),
            nameof(ColorFactoryTestCases))]
        public void FactoryReturnsRedColorOnRCombination((RgbChannels Input, Type Return) args)
            => Assert.That(_colorFactory.Get(args.Input), Is.TypeOf(args.Return));

        [Test]
        public void FactoryThrowsNotImplementedExceptionOnUnknownEnum()
            => Assert.Throws<NotSupportedException>(
                () => _colorFactory.Get(RgbChannels.Unknown)
            );
    }
}
