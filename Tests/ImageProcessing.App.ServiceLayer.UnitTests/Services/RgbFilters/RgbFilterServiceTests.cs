using System;
using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainModel.Factory.RgbFilters.Rgb.Interface;
using ImageProcessing.App.DomainModel.Model.RgbFilters.Implementation.Binary;
using ImageProcessing.App.ServiceLayer.Services.RgbFilters.Implementation;
using ImageProcessing.App.ServiceLayer.Services.RgbFilters.Interface;

using NSubstitute;

using NUnit.Framework;

namespace ImageProcessing.App.ServiceLayer.UnitTests.Services.RgbFilters
{
    [TestFixture]
    internal sealed class RgbFilterServiceTests : IDisposable
    {
        private IRgbFilterFactory _filterFactory;
        private IRgbFilterService _filterService;
        private Bitmap _frame1920x1080;

        [SetUp]
        public void SetUp()
        {
            _frame1920x1080 = new Bitmap(Properties.Frames._1920x1080frame);

            _filterFactory = Substitute.For<IRgbFilterFactory>();
            _filterService = new RgbFilterService();
        }

        [Test]
        public void ServiceThrowsArgumentNullExceptionIfBitmapSourceIsNull()
        {
            _filterFactory.Get(RgbFilter.Binary).Returns(new BinaryFilter());

            var filter = _filterFactory.Get(RgbFilter.Binary);

            Assert.Throws<ArgumentNullException>(() => _filterService.Filter(null, filter));
        }

        [Test]
        public void ServiceThrowsArgumentNullExceptionIfFiltersNull()
        {
            Assert.Throws<ArgumentNullException>(() => _filterService.Filter(_frame1920x1080, null));
        }

        [TearDown]
        public void Dispose()
        {
            _frame1920x1080.Dispose();
        }
    }
}
