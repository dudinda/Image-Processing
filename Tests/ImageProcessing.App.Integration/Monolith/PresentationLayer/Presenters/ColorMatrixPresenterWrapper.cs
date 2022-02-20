using System.Threading.Tasks;

using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Rgb.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.BitmapCopy.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Logger.Interface;
using ImageProcessing.App.PresentationLayer.DomainEvents.ColorMatrixArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.ColorMatrix.Interface;
using ImageProcessing.App.PresentationLayer.Presenters;
using ImageProcessing.App.PresentationLayer.ViewModels;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.Integration.Monolith.PresentationLayer.Presenters
{
    internal class ColorMatrixPresenterWrapper : BasePresenter<IColorMatrixView, BitmapViewModel>,
        ISubscriber<ApplyColorMatrixEventArgs>, ISubscriber<ContainerUpdatedEventArgs>,
        ISubscriber<CustomColorMatrixEventArgs>, ISubscriber<ChangeColorMatrixEventArgs>,
        ISubscriber<ApplyCustomColorMatrixEventArgs>, ISubscriber<RestoreFocusEventArgs>
    {
        public override IColorMatrixView View
            => _presenter.View;

        private readonly ColorMatrixPresenter _presenter;

        public IRgbProviderWrapper Provider { get; }
        public IBitmapCopyServiceWrapper Copy { get; }
        public IColorMatrixFactoryWrapper Factory { get; }
        public ILoggerServiceWrapper Logger { get; }

        public ColorMatrixPresenterWrapper(
            IBitmapCopyServiceWrapper copy,
            IColorMatrixFactoryWrapper factory,
            ILoggerServiceWrapper logger,
            IRgbProviderWrapper provider)
        {
            Provider = provider;
            Factory = factory;
            Copy = copy;
            Logger = logger;

            _presenter = new ColorMatrixPresenter(copy, factory, logger, provider);
        }

        public override void Run(BitmapViewModel vm)
        {
            _presenter.Run(vm);
            base.Run(vm);
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
