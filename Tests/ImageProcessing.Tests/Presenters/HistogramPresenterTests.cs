using System.Drawing;
using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Controller.Interface;
using ImageProcessing.Presentation.Presenters;
using ImageProcessing.Presentation.ViewModel.Histogram;
using ImageProcessing.Presentation.Views.Histogram;
using ImageProcessing.Services.DistributionServices.BitmapLuminanceDistribution.Interface;
using NSubstitute;
using NUnit.Framework;

namespace ImageProcessing.Tests.Presenters
{
    [TestFixture]
    public class HistogramPresenterTests
    {
        private IAppController _controller;
        private HistogramPresenter _presenter;
        private IHistogramView _view;
        private IBitmapLuminanceDistributionService _distibutionService;

        [SetUp]
        public void SetUp()
        {
            _controller = Substitute.For<IAppController>();
            _distibutionService = Substitute.For<IBitmapLuminanceDistributionService>();
            _view = Substitute.For<IHistogramView>();
          

            _presenter = new HistogramPresenter(_controller,
                                                _view,
                                                _distibutionService);
            _presenter.Run(new HistogramViewModel(null, RandomVariable.PMF ) );
        }


    }
}
