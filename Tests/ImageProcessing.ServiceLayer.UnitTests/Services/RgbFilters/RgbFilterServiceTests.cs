using System;
using System.Drawing;
using System.IO;

using ImageProcessing.Common.Enums;
using ImageProcessing.DomainModel.Factory.RgbFilters.Rgb.Interface;
using ImageProcessing.DomainModel.Model.RgbFilters.Implementation.Binary;
using ImageProcessing.ServiceLayer.Services.RgbFilters.Interface;

using NSubstitute;
using NSubstitute.ExceptionExtensions;

using NUnit.Framework;

namespace ImageProcessing.ServiceLayer.UnitTests.Services.RgbFilters
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
            _filterService = Substitute.For<IRgbFilterService>();
        }

        [Test]
        public void ServiceThrowsArgumentNullExceptionIfBitmapSourceIsNull()
        {
            _filterFactory.Get(RgbFilter.Binary).Returns(new BinaryFilter());

            var filter = _filterFactory.Get(RgbFilter.Binary);

            _filterService.Filter(null, filter).Throws(new ArgumentException());

            Assert.Throws<ArgumentException>(() => _filterService.Filter(null, filter));
        }

        [Test]
        public void ServiceThrowsArgumentNullExceptionIfFiltersNull()
        {
            _filterService.Filter(_frame1920x1080, null).Throws(new ArgumentException());

            Assert.Throws<ArgumentException>(() => _filterService.Filter(_frame1920x1080, null));
        }

        [TearDown]
        public void Dispose()
        {
            _frame1920x1080.Dispose();
        }
    }
}
