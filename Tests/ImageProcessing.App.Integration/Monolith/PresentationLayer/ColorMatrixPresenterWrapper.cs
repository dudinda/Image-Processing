
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.DomainFactory.ColorMatrix.Interface;
using ImageProcessing.App.PresentationLayer.DomainEvents.ColorMatrixArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.Presenters;
using ImageProcessing.App.PresentationLayer.ViewModels;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Providers.Rgb.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Win.Services.Logger.Interface;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.Integration.Monolith.PresentationLayer
{
    internal class ColorMatrixPresenterWrapper : BasePresenter<IColorMatrixView, BitmapViewModel>,
        ISubscriber<ApplyColorMatrixEventArgs>,
        ISubscriber<ContainerUpdatedEventArgs>,
        ISubscriber<CustomColorMatrixEventArgs>,
        ISubscriber<ChangeColorMatrixEventArgs>,
        ISubscriber<ApplyCustomColorMatrixEventArgs>,
        ISubscriber<RestoreFocusEventArgs>
    {
        private readonly ColorMatrixPresenter _presenter;

        public IRgbProvider Provider { get; }
        public IAsyncOperationLocker Locker { get; }
        public IColorMatrixFactory Factory { get; }
        public ILoggerService Logger { get; }

        public ColorMatrixPresenterWrapper(
            IAsyncOperationLocker locker,
            IColorMatrixFactory factory,
            ILoggerService logger,
            IRgbProvider provider)
        {
            Provider = provider;
            Factory = factory;
            Locker = locker;
            Logger = logger;

            _presenter = new ColorMatrixPresenter(locker, factory, logger, provider);
        }

        public override void Run(BitmapViewModel vm)
        {
            base.Run(vm);
            _presenter.Run(vm);
        }

        public virtual Task OnEventHandler(object publisher, ApplyColorMatrixEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, ContainerUpdatedEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, CustomColorMatrixEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, ChangeColorMatrixEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, ApplyCustomColorMatrixEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, RestoreFocusEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
