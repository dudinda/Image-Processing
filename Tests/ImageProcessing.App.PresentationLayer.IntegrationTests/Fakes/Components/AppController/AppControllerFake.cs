using ImageProcessing.Microkernel.MVP.Aggregator.Interface;
using ImageProcessing.Microkernel.MVP.Controller.Interface;
using ImageProcessing.Microkernel.MVP.IoC.Interface;
using ImageProcessing.Microkernel.MVP.Presenter;

namespace ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Components
{
    internal class AppControllerFake : IAppControllerFake
    {
        private IAppController _controller;

        public AppControllerFake(IAppController controller)
        {
            _controller = controller;
        }

        public virtual IDependencyResolution IoC
            => _controller.IoC;

        public virtual IEventAggregator Aggregator
            => _controller.Aggregator;

        public virtual void Dispose()
            => _controller.Dispose();

        public virtual void Run<TPresenter>()
            where TPresenter : class, IPresenter
            => _controller.Run<TPresenter>();

        public virtual void Run<TPresenter, TViewModel>(TViewModel vm)
             where TPresenter : class, IPresenter<TViewModel>
             where TViewModel : class
            => _controller.Run<TPresenter, TViewModel>(vm);
    }
}
