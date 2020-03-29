namespace ImageProcessing.ServiceLayer.UnitTests.Services.RgbFilters
{
    internal sealed class RgbFilterServiceTests
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
