using System.Threading.Tasks;

using ImageProcessing.App.Integration.Monolith.Domain.Providers.Transformation.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.BitmapCopy.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Logger.Interface;
using ImageProcessing.App.Presentation.DomainEvents.CommonArgs;
using ImageProcessing.App.Presentation.DomainEvents.TransformationArgs;
using ImageProcessing.App.Presentation.Presenters;
using ImageProcessing.App.Presentation.ViewModels;
using ImageProcessing.App.Presentation.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.Integration.Monolith.Presentation.Presenters
{
    internal class TransformationPresenterWrapper : BasePresenter<ITransformationView, BitmapViewModel>,
        ISubscriber<ApplyTransformationEventArgs>, ISubscriber<ContainerUpdatedEventArgs>,
        ISubscriber<RestoreFocusEventArgs>, ISubscriber<FormIsClosedEventArgs>,
        ISubscriber<EnableControlEventArgs>
    {
        private readonly TransformationPresenter _presenter;

        public override ITransformationView View
            => _presenter.View;

        public ILoggerServiceWrapper Logger { get; }
        public IBitmapCopyServiceWrapper Copy { get; }
        public ITransformationProviderWrapper Provider { get; }

        public TransformationPresenterWrapper(
            ITransformationProviderWrapper provider,
            IBitmapCopyServiceWrapper copy,
            ILoggerServiceWrapper logger)
        {
            Logger = logger;
            Copy = copy;
            Provider = provider;

            _presenter = new TransformationPresenter(copy, provider, logger);
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

        public Task OnEventHandler(object publisher, FormIsClosedEventArgs e)
        {
            return Task.CompletedTask;
        }

        public Task OnEventHandler(object publisher, EnableControlEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
