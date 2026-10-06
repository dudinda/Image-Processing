using System;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Providers.Rgb;
using ImageProcessing.App.Domain.Services.BitmapCopyReference.Interface;
using ImageProcessing.App.Domain.Services.Factories.Rgb;
using ImageProcessing.App.Domain.Services.Pipeline.Implementation;
using ImageProcessing.App.Presentation.Code.Enums;
using ImageProcessing.App.Presentation.DomainEvents.CommonArgs;
using ImageProcessing.App.Presentation.DomainEvents.RgbArgs;
using ImageProcessing.App.Presentation.Properties;
using ImageProcessing.App.Presentation.ViewModels;
using ImageProcessing.App.Presentation.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

using Microsoft.Extensions.Logging;

namespace ImageProcessing.App.Presentation.Presenters
{
    internal sealed class RgbPresenter : BasePresenter<IRgbView, BitmapViewModel>,
        ISubscriber<ApplyRgbFilterEventArgs>, ISubscriber<ApplyRgbChannelFilterEventArgs>,
        ISubscriber<ContainerUpdatedEventArgs>, ISubscriber<ShowColorMatrixMenuEventArgs>,
        ISubscriber<ShowTooltipOnErrorEventArgs>, ISubscriber<RestoreFocusEventArgs>,
        ISubscriber<FormIsClosedEventArgs>, ISubscriber<EnableControlEventArgs>
    {
        private readonly IRgbProvider _provider;
        private readonly ILogger<RgbPresenter> _logger;
        private readonly IBitmapCopyService _reference;
        private readonly IRgbFilterFactory _factory;

        public RgbPresenter(
            IBitmapCopyService reference,
            IRgbFilterFactory factory,
            ILogger<RgbPresenter> logger,
            IRgbProvider provider) 
        {
            _provider = provider;
            _reference = reference;
            _factory = factory;
            _logger = logger;
        }

        /// <inheritdoc cref="ApplyRgbFilterEventArgs"/>
        public async Task OnEventHandler(object publisher, ApplyRgbFilterEventArgs e)
        {
            try
            {
                var filter = View.Dropdown;

                if (filter != RgbFltr.Unknown)
                {
                    var color = View.GetSelectedChannels();

                    var copy = await _reference.GetCopy().ConfigureAwait(true);

                    Aggregator.PublishFromAll(publisher,
                        new AttachBlockToRendererEventArgs(
                            block: new PipelineBlock(copy)
                                .Add<Bitmap, Bitmap>(
                                    (bmp) => _factory.Get(color).Filter(bmp))
                                .Add<Bitmap, Bitmap>(
                                    (bmp) => _factory.Get(filter).Filter(bmp))
                        )
                     );
                }
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.ApplyRgbFilter);
                _logger.LogError(ex.Message);
            }
        }

        /// <inheritdoc cref="ApplyRgbChannelFilterEventArgs"/>
        public async Task OnEventHandler(object publisher, ApplyRgbChannelFilterEventArgs e)
        {
            try
            {
                var color = View.GetSelectedChannels();

                var copy = await _reference.GetCopy().ConfigureAwait(true);

                Aggregator.PublishFromAll(publisher,
                    new AttachBlockToRendererEventArgs(
                        block: new PipelineBlock(copy)
                            .Add<Bitmap, Bitmap>(
                                (bmp) => _provider.Apply(bmp, color))
                    )
                 );
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.ApplyColorFilter);
                _logger.LogError(ex.Message);
            }
        }

        /// <inheritdoc cref="ContainerUpdatedEventArgs"/>
        public Task OnEventHandler(object publisher, ContainerUpdatedEventArgs e)
        {
            try
            {
                ViewModel.SelectedArea = e.Area;
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.UpdatingViewModel);
                _logger.LogError(ex.Message);
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowColorMatrixMenuEventArgs"/>
        public async Task OnEventHandler(object publisher, ShowColorMatrixMenuEventArgs e)
        {
            try
            {
                var copy = await _reference.GetCopy().ConfigureAwait(true);

                Controller.Run<ColorMatrixPresenter, BitmapViewModel>(
                   new BitmapViewModel(new Rectangle(0, 0, copy.Width, copy.Height)));
            }
            catch(Exception ex)
            {
                View.Tooltip(Errors.ShowColorMatrixMenu);
                _logger.LogError(ex.Message);
            }
        }

        /// <inheritdoc cref="ShowTooltipOnErrorEventArgs"/>
        public Task OnEventHandler(object publisher, ShowTooltipOnErrorEventArgs e)
        {
            try
            {
                View.Tooltip(e.Message);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc cref="RestoreFocusEventArgs"/>
        public Task OnEventHandler(object publisher, RestoreFocusEventArgs e)
        {
            try
            {
                View.Focus();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Task.CompletedTask;
        }

        public Task OnEventHandler(object publisher, FormIsClosedEventArgs e)
        {
            try
            {
                View.Close();
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.UpdatingViewModel);
                _logger.LogError(ex.Message);
            }

            return Task.CompletedTask;
        }

        public Task OnEventHandler(object publisher, EnableControlEventArgs e)
        {
            try
            {
                View.EnableControls(e.State != MenuBtnState.ImageEmpty);
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.UpdatingViewModel);
                _logger.LogError(ex.Message);
            }

            return Task.CompletedTask;
        }
    }
}
