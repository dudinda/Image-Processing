using ImageProcessing.Core.AppController.Interface;
using ImageProcessing.Factory.Base;
using ImageProcessing.Presentation.Presenters;
using ImageProcessing.Presentation.Views.Main;

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

        [SetUp]
        public void SetUp()
        {
            _controller  = Substitute.For<IAppController>();
            _baseFactory = Substitute.For<IBaseFactory>();
            _view        = Substitute.For<IMainView>();

         //   _presenter = new MainPresenter(_controller, _view, _baseFactory);
          //  _presenter.Run();
        }

        [TestCase("BoxBlur3x3", "GaussianBlur3x3")]
        public async void ApplyConvolutionFilter(string filterName)
        {
            
        } 
    }
}
