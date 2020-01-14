using ImageProcessing.Core.Controller.Interface;
using ImageProcessing.Core.Factory.Base;
using ImageProcessing.Presentation.Presenters.Main;
using ImageProcessing.Presentation.Views.Main;
using ImageProcessing.Services.ConvolutionFilterServices.Interface;
using ImageProcessing.Services.DistributionServices.BitmapLuminanceDistribution.Interface;
using ImageProcessing.Services.RGBFilterService.Interface;

using NSubstitute;

using NUnit.Framework;


namespace ImageProcessing.Tests.Presenters
{
    [TestFixture]
    public class MainPresenterTests
    {
        private IAppController _controller;
        private MainPresenter _presenter;
        private IMainView _view;
        private IBaseFactory _baseFactory;
        private IConvolutionFilterService _convolutionFilterService;
        private IBitmapLuminanceDistributionService _bitmapLuminanceDistributionFilter;
        private IRGBFilterService _rgbFilterService;

        [SetUp]
        public void SetUp()
        {
            _controller  = Substitute.For<IAppController>();
            _baseFactory = Substitute.For<IBaseFactory>();
            _view        = Substitute.For<IMainView>();
            _convolutionFilterService = Substitute.For<IConvolutionFilterService>();
            _bitmapLuminanceDistributionFilter = Substitute.For<IBitmapLuminanceDistributionService>();
            _rgbFilterService = Substitute.For<IRGBFilterService>();

            _presenter = new MainPresenter(_controller,
                                           _view, 
                                           _baseFactory,
                                           _convolutionFilterService,
                                           _bitmapLuminanceDistributionFilter,
                                           _rgbFilterService);
          _presenter.Run();
        }

        [Test]
        [TestCase("BoxBlur3x3", "GaussianBlur3x3")]
        public async void ApplyConvolutionFilter(string filterName)
        {
            
        } 
    }
}
