using System;
using System.Drawing;

using ImageProcessing.Common.Enums;
using ImageProcessing.DomainModel.Factory.RgbFilters.Interface;
using ImageProcessing.ServiceLayer.Services.RgbFilter.Interface;

using NSubstitute;

using NUnit.Framework;

namespace ImageProcessing.Tests.Services
{
    [TestFixture]
    internal class RgbFilterServiceTests
    {
        private IRgbFilterService _filterService;
        private IRgbFilterFactory _rgbFilterFactory;

        [SetUp]
        public void SetUp()
        {
            _filterService = Substitute.For<IRgbFilterService>();
            _rgbFilterFactory = Substitute.For<IRgbFilterFactory>();
        }

        [TestCase(RgbFilter.Binary)]
        public void ServiceThrowsArgumentNullExceptionIfBitmapSourceIsNull(RgbFilter filterType)
        {
            var filter = _rgbFilterFactory.Get(filterType);
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
