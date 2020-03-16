
using ImageProcessing.Core.Controller.Interface;
using ImageProcessing.Core.EventAggregator.Interface;
using ImageProcessing.Core.Pipeline.AwaitablePipeline.Interface;
using ImageProcessing.PresentationLayer.Presenters.Main;
using ImageProcessing.PresentationLayer.Views.Main;
using ImageProcessing.ServiceLayer.Providers.Interface.BitmapDistribution;
using ImageProcessing.ServiceLayer.Providers.Interface.RgbFilter;
using ImageProcessing.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.ServiceLayer.Services.LockerService.Zoom.Interface;
using ImageProcessing.ServiceLayer.Services.StaTask.Interface;

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
        private IEventAggregator _eventAggregator;
        private ISTATaskService _staTaskService;
        private IAsyncOperationLocker _operationLocker;
        private IAsyncZoomLocker _zoomLocker;
        private IAwaitablePipeline _pipeline;
        private IBitmapLuminanceDistributionServiceProvider _lumaProvider;
        private IRgbFilterServiceProvider _rgbProvider;

        [SetUp]
        public void SetUp()
        {
            _controller      = Substitute.For<IAppController>();
            _view            = Substitute.For<IMainView>();
            _eventAggregator = Substitute.For<IEventAggregator>();
            _staTaskService  = Substitute.For<ISTATaskService>();
            _pipeline        = Substitute.For<IAwaitablePipeline>();
            _operationLocker = Substitute.For<IAsyncOperationLocker>();
            _zoomLocker      = Substitute.For<IAsyncZoomLocker>();
            _lumaProvider    = Substitute.For<IBitmapLuminanceDistributionServiceProvider>();
            _rgbProvider     = Substitute.For<IRgbFilterServiceProvider>();

            _presenter = new MainPresenter(_controller,
                                           _view,
                                           _staTaskService,
                                           _eventAggregator,
                                           _pipeline,
                                           _zoomLocker,
                                           _operationLocker,
                                           _lumaProvider,
                                           _rgbProvider);
          _presenter.Run();
        }

        [Test]
        [TestCase("BoxBlur3x3", "GaussianBlur3x3")]
        public async void ApplyConvolutionFilter(string filterName)
        {
            
        } 
    }
}
