using System.Threading.Tasks;

using ImageProcessing.App.Domain.Services.FileDialog;
using ImageProcessing.App.Integration.Monolith.Domain.Services.BitmapCopy.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.FileDialog.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.NonBlockDialog.Interface;
using ImageProcessing.App.Presentation.DomainEvents.MainArgs.FileDialog;
using ImageProcessing.App.Presentation.DomainEvents.MainArgs.Menu;
using ImageProcessing.App.Presentation.DomainEvents.MainArgs.Show;
using ImageProcessing.App.Presentation.Presenters;
using ImageProcessing.App.Presentation.ViewModels;
using ImageProcessing.App.Presentation.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

using Microsoft.Extensions.Logging;

namespace ImageProcessing.App.Integration.Monolith.Presentation.Presenters
{
    internal class MainMenuPresenterWrapper : BasePresenter<IMainView>,
        ISubscriber<ShowConvolutionMenuEventArgs>, ISubscriber<ShowDistributionMenuEventArgs>,
        ISubscriber<ShowRgbMenuEventArgs>, ISubscriber<ShowSettingsMenuEventArgs>,
        ISubscriber<ShowTransformationMenuEventArgs>, ISubscriber<ShowRotationMenuEventArgs>,
        ISubscriber<ShowScalingMenuEventArgs>, ISubscriber<OpenFileDialogEventArgs>,
        ISubscriber<SaveAsFileDialogEventArgs>, ISubscriber<SaveWithoutFileDialogEventArgs>
    {
        private readonly MainMenuPresenter _presenter;

        public override IMainView View
            => _presenter.View;

        public override void Run()
        {
            _presenter.Run();
            Aggregator.Subscribe(this, View);
            base.Run();
        }

        public ILoggerFactory Logger { get; }
        public IBitmapCopyServiceWrapper Reference { get; }
        public INonBlockDialogServiceWrapper Dialog { get; }

        public MainMenuPresenterWrapper(
            ILoggerFactory logger,
            IBitmapCopyServiceWrapper reference,
            INonBlockDialogServiceWrapper dialog
            )
        {
            Logger = logger;
            Reference = reference;
            Dialog = dialog;

            _presenter = new MainMenuPresenter(reference, dialog, Logger.CreateLogger<MainMenuPresenter>());
        }

        /// <inheritdoc cref="ShowRgbMenuEventArgs"/>
        public virtual Task OnEventHandler(object publisher, ShowRgbMenuEventArgs e)
        {
            Controller.Run<RgbPresenterWrapper, BitmapViewModel>(
                new BitmapViewModel(new System.Drawing.Rectangle()));

            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowScalingMenuEventArgs"/>
        public virtual Task OnEventHandler(object publisher, ShowScalingMenuEventArgs e)
        {
            Controller.Run<ScalingPresenterWrapper, BitmapViewModel>(
               new BitmapViewModel(new System.Drawing.Rectangle()));

            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowRotationMenuEventArgs"/>
        public virtual Task OnEventHandler(object publisher, ShowRotationMenuEventArgs e)
        {
            Controller.Run<RotationPresenterWrapper, BitmapViewModel>(
               new BitmapViewModel(new System.Drawing.Rectangle()));

            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowDistributionMenuEventArgs"/>
        public virtual Task OnEventHandler(object publisher, ShowDistributionMenuEventArgs e)
        {
            Controller.Run<DistributionPresenterWrapper, BitmapViewModel>(
               new BitmapViewModel(new System.Drawing.Rectangle()));

            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowConvolutionMenuEventArgs"/>
        public virtual Task OnEventHandler(object publisher, ShowConvolutionMenuEventArgs e)
        {
            Controller.Run<ConvolutionPresenterWrapper, BitmapViewModel>(
               new BitmapViewModel(new System.Drawing.Rectangle()));

            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowTransformationMenuEventArgs"/>
        public virtual Task OnEventHandler(object publisher, ShowTransformationMenuEventArgs e)
        {
            Controller.Run<TransformationPresenterWrapper, BitmapViewModel>(
               new BitmapViewModel(new System.Drawing.Rectangle()));

            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowSettingsMenuEventArgs"/>
        public virtual Task OnEventHandler(object publisher, ShowSettingsMenuEventArgs e)
        {
            Controller.Run<SettingsPresenterWrapper>();

            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, OpenFileDialogEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, SaveWithoutFileDialogEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, SaveAsFileDialogEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
