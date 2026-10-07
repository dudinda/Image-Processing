using System.Threading.Tasks;

using ImageProcessing.App.Integration.Monolith.Domain.Providers.Rgb.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.BitmapCopy.Interface;
using ImageProcessing.App.Presentation.DomainEvents.ColorMatrixArgs;
using ImageProcessing.App.Presentation.DomainEvents.CommonArgs;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.ColorMatrix.Interface;
using ImageProcessing.App.Presentation.Presenters;
using ImageProcessing.App.Presentation.ViewModels;
using ImageProcessing.App.Presentation.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

using Microsoft.Extensions.Logging;

namespace ImageProcessing.App.Integration.Monolith.Presentation.Presenters
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
        public ILoggerFactory Logger { get; }

        public ColorMatrixPresenterWrapper(
            IBitmapCopyServiceWrapper copy,
            IColorMatrixFactoryWrapper factory,
            ILoggerFactory logger,
            IRgbProviderWrapper provider)
        {
            Provider = provider;
            Factory = factory;
            Copy = copy;
            Logger = logger;

            _presenter = new ColorMatrixPresenter(copy, factory, logger.CreateLogger<ColorMatrixPresenter>(), provider);
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
