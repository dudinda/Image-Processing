using System.Drawing;

using ImageProcessing.Core.Controller.Interface;
using ImageProcessing.Core.EventAggregator.Interface;
using ImageProcessing.Core.Factory.Base;
using ImageProcessing.Core.Locker.Interface;
using ImageProcessing.Core.Pipeline.AwaitablePipeline.Interface;
using ImageProcessing.Core.Service.STATask;
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
        private IEventAggregator _eventAggregator;
        private IConvolutionFilterService _convolutionFilterService;
        private IBitmapLuminanceDistributionService _bitmapLuminanceDistributionFilter;
        private IRGBFilterService _rgbFilterService;
        private ISTATaskService _staTaskService;
        private IAsyncLocker _operationLocker;
        private IAsyncLocker _zoomLocker;
        private IAwaitablePipeline<Bitmap> _pipeline;

        [SetUp]
        public void SetUp()
        {
            _controller      = Substitute.For<IAppController>();
            _baseFactory     = Substitute.For<IBaseFactory>();
            _view            = Substitute.For<IMainView>();
            _eventAggregator = Substitute.For<IEventAggregator>();
            _staTaskService  = Substitute.For<ISTATaskService>();
            _pipeline        = Substitute.For<IAwaitablePipeline<Bitmap>>();

            _convolutionFilterService          = Substitute.For<IConvolutionFilterService>();
            _bitmapLuminanceDistributionFilter = Substitute.For<IBitmapLuminanceDistributionService>();
            _rgbFilterService                  = Substitute.For<IRGBFilterService>();

            _presenter = new MainPresenter(_controller,
                                           _view,
                                           _baseFactory,
                                           _bitmapLuminanceDistributionFilter,
                                           _staTaskService,
                                           _rgbFilterService,
                                           _eventAggregator,
                                           _pipeline,
                                           _zoomLocker,
                                           _operationLocker);
          _presenter.Run();
        }

        [Test]
        [TestCase("BoxBlur3x3", "GaussianBlur3x3")]
        public async void ApplyConvolutionFilter(string filterName)
        {
            
        } 
    }
}
