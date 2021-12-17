using System.Threading.Tasks;

using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.TransformationArgs;
using ImageProcessing.App.PresentationLayer.Presenters;
using ImageProcessing.App.PresentationLayer.ViewModels;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Providers.Transformation.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Win.Services.Logger.Interface;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.Integration.Monolith.PresentationLayer
{
    internal class TransformationPresenterWrapper : BasePresenter<ITransformationView, BitmapViewModel>,
        ISubscriber<ApplyTransformationEventArgs>,
        ISubscriber<ContainerUpdatedEventArgs>,
        ISubscriber<RestoreFocusEventArgs>
    {
        private readonly TransformationPresenter _presenter;

        public ILoggerService Logger { get; }
        public IAsyncOperationLocker Locker { get; }
        public ITransformationProvider Provider { get; }

        public TransformationPresenterWrapper(
            ITransformationProvider provider,
            IAsyncOperationLocker locker,
            ILoggerService logger)
        {
            Logger = logger;
            Locker = locker;
            Provider = provider;

            _presenter = new TransformationPresenter(provider, locker, logger);
        }

        public virtual Task OnEventHandler(object publisher, RestoreFocusEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, ApplyTransformationEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, ContainerUpdatedEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
