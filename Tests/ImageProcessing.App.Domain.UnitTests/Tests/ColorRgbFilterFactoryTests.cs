using System;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.UnitTests.CaseFactory;
using ImageProcessing.App.Domain.Services.Factories.Rgb;
using ImageProcessing.App.Domain.Services.Factories.Rgb.Implementation;

using NUnit.Framework;

using static ImageProcessing.App.Domain.UnitTests.CaseFactory.DomainFactoriesCaseFactory;

namespace ImageProcessing.App.Domain.UnitTests.Factory.Color
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
            typeof(DomainFactoriesCaseFactory),
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
