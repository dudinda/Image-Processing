using System.Threading.Tasks;

using ImageProcessing.App.Presentation.DomainEvents.MainArgs.Container;
using ImageProcessing.App.Presentation.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

using Microsoft.Extensions.Logging;

namespace ImageProcessing.App.Integration.Monolith.Presentation.Presenters
{
    internal class MainToolbarPresenterWrapper : BasePresenter<IMainView>,
        ISubscriber<SetSourceEventArgs>, ISubscriber<UndoRedoEventArgs>
    {
        public override IMainView View
           => field ??= Controller.IoC.Resolve<IMainView>();

        public override void Run()
        {
            Aggregator.Subscribe(this, View);
        }

        public ILoggerFactory Logger { get; }

        public MainToolbarPresenterWrapper(
            ILoggerFactory logger
            )
        {
            Logger = logger;
        }
        public virtual Task OnEventHandler(object publisher, SetSourceEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, UndoRedoEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
