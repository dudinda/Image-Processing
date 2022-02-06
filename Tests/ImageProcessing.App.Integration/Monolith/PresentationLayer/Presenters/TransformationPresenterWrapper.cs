using System.Threading.Tasks;

using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Transformation.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.BitmapCopy.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Logger.Interface;
using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.TransformationArgs;
using ImageProcessing.App.PresentationLayer.Presenters;
using ImageProcessing.App.PresentationLayer.ViewModels;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.Integration.Monolith.PresentationLayer
{
    internal class TransformationPresenterWrapper : BasePresenter<ITransformationView, BitmapViewModel>,
        ISubscriber<ApplyTransformationEventArgs>, ISubscriber<ContainerUpdatedEventArgs>,
        ISubscriber<RestoreFocusEventArgs>
    {
        private readonly TransformationPresenter _presenter;

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
    }
}
