using System;

using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.UnitTests.CaseFactory;
using ImageProcessing.App.ServiceLayer.Services.Factories.Rgb;
using ImageProcessing.App.ServiceLayer.Services.Factories.Rgb.Implementation;

using NUnit.Framework;

using static ImageProcessing.App.ServiceLayer.UnitTests.CaseFactory.ServiceLayerFactoriesCaseFactory;

namespace ImageProcessing.App.ServiceLayer.UnitTests.Factory.Color
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
            typeof(ServiceLayerFactoriesCaseFactory),
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
