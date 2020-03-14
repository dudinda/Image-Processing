using ImageProcessing.Core.Controller.Interface;
using ImageProcessing.Core.EventAggregator.Interface;
using ImageProcessing.Core.Pipeline.AwaitablePipeline.Interface;
using ImageProcessing.Presentation.Presenters;
using ImageProcessing.Presentation.Views.Histogram;
using ImageProcessing.ServiceLayer.Services.Distributions.BitmapLuminance.Interface;

using NSubstitute;

using NUnit.Framework;

namespace ImageProcessing.Tests.Presenters
{
    [TestFixture]
    public class HistogramPresenterTests
    {
        private IAppController _controller;
        private HistogramPresenter _presenter;
        private IEventAggregator _aggregator;
        private IAwaitablePipeline _pipeline;
        private IHistogramView _view;
        private IBitmapLuminanceDistributionService _distibutionService;

        [SetUp]
        public void SetUp()
        {
            _controller = Substitute.For<IAppController>();
            _distibutionService = Substitute.For<IBitmapLuminanceDistributionService>();
            _view = Substitute.For<IHistogramView>();
            _pipeline = Substitute.For<IAwaitablePipeline>();
            _aggregator = Substitute.For<IEventAggregator>();

            _presenter = new HistogramPresenter(_controller,
                                                _view,
                                                _pipeline,
                                                _aggregator,
                                                _distibutionService);
        }


    }
}
