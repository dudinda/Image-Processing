using System;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.Domain.Services.BitmapCopyReference.Interface;
using ImageProcessing.App.Domain.Services.FileDialog;
using ImageProcessing.App.Domain.Services.Pipeline.Implementation;
using ImageProcessing.App.Domain.Win.Code.Extensions;
using ImageProcessing.App.Presentation.Code.Enums;
using ImageProcessing.App.Presentation.DomainEvents.CommonArgs;
using ImageProcessing.App.Presentation.DomainEvents.MainArgs.FileDialog;
using ImageProcessing.App.Presentation.DomainEvents.MainArgs.Menu;
using ImageProcessing.App.Presentation.DomainEvents.MainArgs.Show;
using ImageProcessing.App.Presentation.Properties;
using ImageProcessing.App.Presentation.ViewModels;
using ImageProcessing.App.Presentation.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

using Microsoft.Extensions.Logging;

namespace ImageProcessing.App.Presentation.Presenters
{
    internal sealed class MainMenuPresenter : BasePresenter<IMainView>,
        ISubscriber<ShowConvolutionMenuEventArgs>, ISubscriber<ShowDistributionMenuEventArgs>,
        ISubscriber<ShowRgbMenuEventArgs>, ISubscriber<ShowSettingsMenuEventArgs>,
        ISubscriber<ShowTransformationMenuEventArgs>, ISubscriber<ShowRotationMenuEventArgs>,
        ISubscriber<ShowScalingMenuEventArgs>, ISubscriber<OpenFileDialogEventArgs>,
        ISubscriber<SaveAsFileDialogEventArgs>, ISubscriber<SaveWithoutFileDialogEventArgs>
    {
        public override IMainView View
          => field ??= Controller.IoC.Resolve<IMainView>();

        private readonly ILogger<MainMenuPresenter> _logger;
        private readonly IBitmapCopyService _reference;
        private readonly INonBlockDialogService _dialog;

        public MainMenuPresenter(
            IBitmapCopyService reference,
            INonBlockDialogService dialog,
            ILogger<MainMenuPresenter> logger)
        {
            _logger = logger;
            _reference = reference;
            _dialog = dialog;
        }

        public override void Run()
        {
            Aggregator.Subscribe(this, View);
        }

        /// <inheritdoc cref="OpenFileDialogEventArgs"/>
        public async Task OnEventHandler(object publisher, OpenFileDialogEventArgs e)
        {
            try
            {
                var result = await _dialog.OpenFileDialog().ConfigureAwait(true);

                if (result.Image != null)
                {
                    View.LoadedImage = result.Image;
                    Aggregator.PublishFromAll(publisher,
                        new AttachBlockToRendererEventArgs(
                            block: new PipelineBlock(result.Image)
                                .Add<Bitmap>(
                                    (bmp) => View.SetPathToFile(result.Path))
                        )
                     );

                    View.SetMenuState(MenuBtnState.ImageLoaded);
                }
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.OpenFile);
                _logger.LogError(ex.Message);
            }
        }

        /// <inheritdoc cref="SaveAsFileDialogEventArgs"/>
        public async Task OnEventHandler(object publisher, SaveAsFileDialogEventArgs e)
        {
            try
            {
                if (!View.ImageIsDefault)
                {
                    var copy = await _reference.GetCopy().ConfigureAwait(true);
                    await _dialog.SaveFileAsDialog(copy).ConfigureAwait(true);
                }
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.SaveFile);
                _logger.LogError(ex.Message);
            }
        }

        /// <inheritdoc cref="SaveWithoutFileDialogEventArgs"/>
        public async Task OnEventHandler(object publisher, SaveWithoutFileDialogEventArgs e)
        {
            try
            {
                if (!View.ImageIsDefault)
                {
                    var copy = await _reference.GetCopy().ConfigureAwait(true);
                    await Task.Run(() => copy.SaveByPath(View.GetPathToFile())).ConfigureAwait(true);
                }
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.SaveFile);
                _logger.LogError(ex.Message);
            }
        }

        /// <inheritdoc cref="ShowRgbMenuEventArgs"/>
        public async Task OnEventHandler(object publisher, ShowRgbMenuEventArgs e)
        {
            try
            {
                if (!View.ImageIsDefault)
                {
                    var copy = await _reference.GetCopy().ConfigureAwait(true);

                    Controller.Run<RgbPresenter, BitmapViewModel>(
                        new BitmapViewModel(new Rectangle(0, 0, copy.Width, copy.Height)));
                }
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.ShowRgbMenu);
                _logger.LogError(ex.Message);
            }
        }

        /// <inheritdoc cref="ShowScalingMenuEventArgs"/>
        public async Task OnEventHandler(object publisher, ShowScalingMenuEventArgs e)
        {
            try
            {
                if (!View.ImageIsDefault)
                {
                    var copy = await _reference.GetCopy().ConfigureAwait(true);

                    Controller.Run<ScalingPresenter, BitmapViewModel>(
                        new BitmapViewModel(new Rectangle(0, 0, copy.Width, copy.Height)));
                }
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.ShowRgbMenu);
                _logger.LogError(ex.Message);
            }
        }

        /// <inheritdoc cref="ShowRotationMenuEventArgs"/>
        public async Task OnEventHandler(object publisher, ShowRotationMenuEventArgs e)
        {
            try
            {
                if (!View.ImageIsDefault)
                {
                    var copy = await _reference.GetCopy().ConfigureAwait(true);

                    Controller.Run<RotationPresenter, BitmapViewModel>(
                        new BitmapViewModel(new Rectangle(0, 0, copy.Width, copy.Height)));
                }
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.ShowRgbMenu);
                _logger.LogError(ex.Message);
            }
        }

        /// <inheritdoc cref="ShowDistributionMenuEventArgs"/>
        public async Task OnEventHandler(object publisher, ShowDistributionMenuEventArgs e)
        {
            try
            {
                if (!View.ImageIsDefault)
                {
                    var copy = await _reference.GetCopy().ConfigureAwait(true);

                    Controller.Run<DistributionPresenter, BitmapViewModel>(
                        new BitmapViewModel(new Rectangle(0, 0, copy.Width, copy.Height)));
                }
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.ShowDistributionMenu);
                _logger.LogError(ex.Message);
            }
        }

        /// <inheritdoc cref="ShowConvolutionMenuEventArgs"/>
        public async Task OnEventHandler(object publisher, ShowConvolutionMenuEventArgs e)
        {
            try
            {
                if (!View.ImageIsDefault)
                {
                    var copy = await _reference.GetCopy().ConfigureAwait(true);

                    Controller.Run<ConvolutionPresenter, BitmapViewModel>(
                        new BitmapViewModel(new Rectangle(0, 0, copy.Width, copy.Height)));
                }
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.ShowConvolutionMenu);
                _logger.LogError(ex.Message);
            }
        }

        /// <inheritdoc cref="ShowTransformationMenuEventArgs"/>
        public async Task OnEventHandler(object publisher, ShowTransformationMenuEventArgs e)
        {
            try
            {
                if (!View.ImageIsDefault)
                {
                    var copy = await _reference.GetCopy().ConfigureAwait(true);

                    Controller.Run<TransformationPresenter, BitmapViewModel>(
                        new BitmapViewModel(new Rectangle(0, 0, copy.Width, copy.Height)));
                }
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.ShowTransformationMenu);
                _logger.LogError(ex.Message);
            }
        }

        /// <inheritdoc cref="ShowSettingsMenuEventArgs"/>
        public Task OnEventHandler(object publisher, ShowSettingsMenuEventArgs e)
        {
            try
            {
                Controller.Run<SettingsPresenter>();
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.ShowSettingsMenu);
                _logger.LogError(ex.Message);
            }

            return Task.CompletedTask;
        }
    }
}
