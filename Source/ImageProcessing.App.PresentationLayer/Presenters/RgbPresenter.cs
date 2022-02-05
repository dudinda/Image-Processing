using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.RgbFilter.Interface;
using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.RgbArgs;
using ImageProcessing.App.PresentationLayer.Properties;
using ImageProcessing.App.PresentationLayer.ViewModels;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Providers.Rgb.Interface;
using ImageProcessing.App.ServiceLayer.Services.BitmapCopyReference.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Block.Implementation;
using ImageProcessing.App.ServiceLayer.Win.Services.Logger.Interface;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.PresentationLayer.Presenters
{
    internal sealed class RgbPresenter : BasePresenter<IRgbView, BitmapViewModel>,
        ISubscriber<ApplyRgbFilterEventArgs>, ISubscriber<ApplyRgbChannelFilterEventArgs>,
        ISubscriber<ContainerUpdatedEventArgs>, ISubscriber<ShowColorMatrixMenuEventArgs>,
        ISubscriber<ShowTooltipOnErrorEventArgs>, ISubscriber<RestoreFocusEventArgs>,
        ISubscriber<FormIsClosedEventArgs>, ISubscriber<EnableControlEventArgs>
    {
        private readonly IRgbProvider _provider;
        private readonly ILoggerService _logger;
        private readonly IBitmapCopyService _reference;
        private readonly IRgbFilterFactory _factory;

        public RgbPresenter(
            IBitmapCopyService reference,
            IRgbFilterFactory factory,
            ILoggerService logger,
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
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
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
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
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
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
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
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
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
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
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
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
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
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
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
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }

            return Task.CompletedTask;
        }
    }
}
