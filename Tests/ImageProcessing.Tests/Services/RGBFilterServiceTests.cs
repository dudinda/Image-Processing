using System;
using System.Drawing;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Factory.RGBFiltersFactory;
using ImageProcessing.Services.RGBFilterService.Interface;

using NSubstitute;

using NUnit.Framework;

namespace ImageProcessing.Tests.Services
{
    [TestFixture]
    internal class RGBFilterServiceTests
    {
        private IRGBFilterService _filterService;
        private IRGBFiltersFactory _rgbFilterFactory;

        [SetUp]
        public void SetUp()
        {
            _filterService = Substitute.For<IRGBFilterService>();
        }

        [TestCase(RGBFilter.Binary)]
        public void ServiceThrowsArgumentNullExceptionIfBitmapSourceIsNull(RGBFilter filterType)
        {
            var filter = _rgbFilterFactory.GetFilter(filterType);
            Assert.Throws<ArgumentNullException>(() => _filterService.Filter(null, filter));
        }

        [Test]
        public void ServiceThrowsArgumentNullExceptionIfFiltersNull()
        {
            var image = Substitute.For<Image>();
            Assert.Throws<ArgumentNullException>(() => _filterService.Filter(new Bitmap(image), null));
        }
    }
}
