using System;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.Domain.Services.BitmapCopyReference.Interface;
using ImageProcessing.App.Domain.Services.Pipeline;
using ImageProcessing.App.Presentation.Code.Enums;
using ImageProcessing.App.Presentation.DomainEvents.CommonArgs;
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
        ISubscriber<ShowScalingMenuEventArgs>
    {
        public override IMainView View
            => field ??= Controller.IoC.Resolve<IMainView>();

        private readonly ILogger<MainMenuPresenter> _logger;
        private readonly IBitmapCopyService _reference;
        private readonly IAwaitablePipeline _pipeline;

        public MainMenuPresenter(
            IBitmapCopyService reference,
            IAwaitablePipeline pipeline,
            ILogger<MainMenuPresenter> logger)
        {
            _logger = logger;
            _reference = reference;
            _pipeline = pipeline;
        }

        public override void Run()
        {
            Aggregator.Subscribe(this, View);
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
                OnError(publisher, Errors.ShowRgbMenu);
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
                OnError(publisher, Errors.ShowRgbMenu);
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
                OnError(publisher, Errors.ShowRgbMenu);
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
                OnError(publisher, Errors.ShowDistributionMenu);
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
                OnError(publisher, Errors.ShowConvolutionMenu);
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
                OnError(publisher, Errors.ShowTransformationMenu);
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
                OnError(publisher, Errors.ShowSettingsMenu);
                _logger.LogError(ex.Message);
            }

            return Task.CompletedTask;
        }

        private void OnError(object publisher, string error)
        {
            if (!_pipeline.Any())
            {
                View.SetCursor(CursorType.Default);
            }
            else
            {
                View.SetCursor(CursorType.Wait);
            }

            Aggregator.PublishFrom(publisher, new ShowTooltipOnErrorEventArgs(error));
        }
    }
}
